import { useEffect, useState } from "react";
import 'react-datepicker/dist/react-datepicker.css';
import userManager, { loadUser, signinRedirect, signoutRedirect } from '../auth/UserService';
import DatePicker from 'react-datepicker';

const URL = `api/user`;

const User = () =>
{
    const [user, setUser] = useState(null);
    const [borrows, setBorrows] = useState([]);

    const getUser = async () => {
        await loadUser();
        const headers = new Headers();
        headers.set('Content-Type', 'application/json');
        const token = localStorage.getItem('token');
        headers.set('Authorization', 'Bearer ' + token);
        const options =
        {
            method: 'GET',
            headers: headers
        }

        const result = await fetch(URL, options);
        console.log(result);
        if (result.ok)
        {
            const user = await result.json();
            setUser(user);
            setBorrows(user.borrows);
            return user;
        }
        return [];
    }


    useEffect(() => {
        getUser();
    }, [])

    return (
        <div>
            <div>
                {borrows?.map(x => <PostItem key={x.id} borrow={x} />)}
            </div>
        </div>
    )
}

export default User;


const PostItem = ({ borrow }) => {

    return (
        <div style={{ backgroundColor: 'whitesmoke', margin: '10px', borderRadius: '10px', padding: '10px' }}>
            <h1>Название</h1>
            <h3>{borrow.book.title}</h3>
            <h1>isbn</h1>
            <h3>{borrow.book.isbn}</h3>
        </div>
    )
}