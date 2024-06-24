import { loadUser } from '../auth/UserService';
import { URL_BOOK, URL_BORROW, URL_FILE } from '../apiUrls';


export const getBooks = async () => {
    const options = {
        method: 'GET',
        headers: new Headers()
    }
    const result = await fetch(URL_BOOK, options);
    if (result.ok) {
        const books = await result.json();
        return books.books;
    }
    return [];
}

export const addBook = async (isbn, title, genre, description, count ,selectedImageFile) => {
    const imagePath = await ImageUpload(selectedImageFile);
    const book = { isbn, title, genre, description, count, imagePath };
    console.log(book);

    await loadUser();
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', 'Bearer ' + token);

    const options =
    {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(book)
    };

    await fetch(URL_BOOK, options);
}

export const updateBook = async (oldBook) =>
{
    await loadUser();
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', 'Bearer ' + token);
    const options = {
        method: 'PUT',
        headers: headers,
        body: JSON.stringify(oldBook)
    };

    await fetch(URL_BOOK, options);
}

export const deleteBook = async (id) => {
    await loadUser();
    const headers = new Headers();
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', 'Bearer ' + token);
    const options = {
        method: 'DELETE',
        headers: headers
    }
    fetch(URL_BOOK + `/${id}`, options);
}

export const ImageUpload = async (selectedImageFile) => {
    if (selectedImageFile != null) {
        const formData = new FormData();
        formData.append('FormFile', selectedImageFile);

        const headers = new Headers();
        headers.set('Content-Type', 'application/json');
        const options =
        {
            method: 'POST',
            body: formData
        };

        const result = await fetch(URL_FILE, options);
        if (result.ok) {
            const path = await result.json();
            return await path;
        }
        return result.path;
    }
    else {
        return null;
    }
};

export const takeBook = async (bookId, returnTime) => {
    await loadUser();
    const headers = new Headers();
    const borrow = { bookId, returnTime };
    headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    headers.set('Authorization', 'Bearer ' + token);

    const options = {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(borrow)
    };

    await fetch(URL_BORROW, options);
}