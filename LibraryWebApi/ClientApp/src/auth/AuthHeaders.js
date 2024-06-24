export const setAuthHeader = (token, role) => {
    localStorage.setItem('token', token || '');
    localStorage.setItem('role', role || '');
};
