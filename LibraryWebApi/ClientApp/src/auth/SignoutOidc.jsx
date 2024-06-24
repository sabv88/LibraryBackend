import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { signoutRedirectCallback } from './UserService';

const SignoutOidc = () => {
    const history = useNavigate();
    useEffect(() => {
        const signoutAsync = async () => {
            await signoutRedirectCallback();
            history('/');
        };
        signoutAsync();
    }, [history]);
    return <div>Redirecting...</div>;
};

export default SignoutOidc;
