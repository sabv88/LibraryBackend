import { loadUser } from '../auth/UserService';
import {  URL_AUTHOR } from '../apiUrls';


export const getAuthors = async () => {
    await loadUser();
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', `Bearer ${token}`);
    const options = {
        method: 'GET',
        headers: headers,
    };
    const result = await fetch(URL_AUTHOR, options);
    if (result.ok) {
        const authors = await result.json();
        return authors.authors;
    }
    return [];
};

export const addAuthor = async (name, surname, country, dateOfBirth) => {
    await loadUser();
    const author = { name, surname, country, dateOfBirth };

    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', `Bearer ${token}`);
    const options = {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(author),
    };

    const result = await fetch(URL_AUTHOR, options);
    if (result.ok) {
        const newAuthor = await result.json();
        return newAuthor;
    }
    return null;
};

export const updateAuthor = async (oldAuthor) => {
    await loadUser();
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', 'Bearer ' + token);
    const options = {
        method: 'PUT',
        headers: headers,
        body: JSON.stringify(oldAuthor)
    };

    await fetch(URL_AUTHOR, options);
};

export const deleteAuthor = async (id) => {
    await loadUser();
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', 'Bearer ' + token);
    const options = {
        method: 'DELETE',
        headers: headers
    }
    fetch(URL_AUTHOR + `/${id}`, options);
};