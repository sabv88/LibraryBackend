export function setAuthHeader(token: string | null | undefined, role: string | null | undefined)
{
    localStorage.setItem('token', token ? token : '');
    localStorage.setItem('role', role ? role : '');
    console.log(token);
    console.log(role);
}