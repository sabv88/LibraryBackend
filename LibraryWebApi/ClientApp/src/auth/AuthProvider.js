import React, { useEffect, useRef } from 'react';
import { UserManager } from 'oidc-client';
import { setAuthHeader } from './auth-headers';

const AuthProvider = ({ userManager, children }) => {
    const userManagerRef = useRef();
    useEffect(() => {
        userManagerRef.current = userManager;
        const onUserLoaded = (user) => {
            setAuthHeader(user.access_token);
        };
        const onUserUnloaded = () => {
            setAuthHeader(null);
        };
        const onAccessTokenExpiring = () => {
            // Handle access token expiring
        };
        const onAccessTokenExpired = () => {
            // Handle access token expired
        };
        const onUserSignedOut = () => {
            // Handle user signed out
        };

        userManagerRef.current.events.addUserLoaded(onUserLoaded);
        userManagerRef.current.events.addUserUnloaded(onUserUnloaded);
        userManagerRef.current.events.addAccessTokenExpiring(
            onAccessTokenExpiring
        );
        userManagerRef.current.events.addAccessTokenExpired(onAccessTokenExpired);
        userManagerRef.current.events.addUserSignedOut(onUserSignedOut);

        return function cleanup() {
            if (userManagerRef.current) {
                userManagerRef.current.events.removeUserLoaded(onUserLoaded);
                userManagerRef.current.events.removeUserUnloaded(onUserUnloaded);
                userManagerRef.current.events.removeAccessTokenExpiring(
                    onAccessTokenExpiring
                );
                userManagerRef.current.events.removeAccessTokenExpired(
                    onAccessTokenExpired
                );
                userManagerRef.current.events.removeUserSignedOut(onUserSignedOut);
            }
        };
    }, [userManager]);

    return React.Children.only(children);
};

export default AuthProvider;
