import { UserManager } from 'oidc-client';
import { setAuthHeader } from './AuthHeaders.js';

const userManagerSettings = {
    client_id: 'library-web-app',
    redirect_uri: 'https://localhost:44410/signin-oidc',
    response_type: 'code',
    scope: 'openid profile LibraryWebAPI',
    authority: 'https://localhost:7287/',
    post_logout_redirect_uri: 'https://localhost:44410/signout-oidc',
};

const userManager = new UserManager(userManagerSettings);

export async function loadUser()
{
    const user = await userManager.getUser();
    const token = user?.access_token;
    setAuthHeader(token, user.profile.role);
}

export const signinRedirect = () => userManager.signinRedirect();

export const signinRedirectCallback = () => {
    userManager.signinRedirectCallback();
};

export const signoutRedirect = (args) => {
    userManager.clearStaleState();
    userManager.removeUser();
    localStorage.setItem('role', null);
    localStorage.setItem('token', null);
    return userManager.signoutRedirect(args);
};

export const signoutRedirectCallback = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirectCallback();
};

export default userManager;
