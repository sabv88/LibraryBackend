import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

import { signinRedirectCallback } from './UserService';

const SigninOidc = () => {
    const history = useNavigate();
    useEffect(() => {
        async function signinAsync() {
            await signinRedirectCallback();
            history('/');
        }
        signinAsync();
    }, [history]);
    return <div>Redirecting...</div>;
};

export default SigninOidc;
