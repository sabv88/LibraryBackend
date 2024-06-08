import { useEffect, useState } from "react";
import ModalButton from "./ModalBtn";
import 'react-datepicker/dist/react-datepicker.css';
import DatePicker from 'react-datepicker';
import userManager, { loadUser, signinRedirect, signoutRedirect } from '../auth/user-service.ts';

const URL = `api/book`;
const URL_BORROW = `api/borrow`;

const Home = () => {
    const [allBooks, setBooks] = useState([]);

    const getBooks = async () =>
    {
        const headers = new Headers();

        const options = {
            method: 'GET',
            headers: headers
        }
        const result = await fetch(URL, options);
        console.log(result);
        if (result.ok) {
            const books = await result.json();
            console.log(books.books);

            setBooks(books.books);
            return books.books;
        }
        return [];
    }

    const takeBook = async (bookId, returnTime) =>
    {
        await loadUser();
        const headers = new Headers();
        const borrow = { bookId, returnTime };
        console.log(bookId);

        headers.set('Content-Type', 'application/json');
        const token = localStorage.getItem('token');
        headers.set('Authorization', 'Bearer ' + token);
        console.log(token);

        const options = {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(borrow)
        };

        const result = await fetch(URL_BORROW, options);
        console.log(result);

        if (result.ok)
        {

        }
    }

    useEffect(() => {
        getBooks();
    }, [])

    return (
        <div>
            <h1>Книги</h1>
            <div>
                {allBooks.map(x => <PostItem key={x.id} book={x} takeAction={takeBook} />)}
            </div>
        </div>
    )
}

const PostItem = ({ book, takeAction }) =>
{
    const [returnTime, setReturnTime] = useState('');

    return (
        <div style={{ backgroundColor: 'whitesmoke', margin: '10px', borderRadius: '10px', padding: '10px' }}>
            <h1>Название</h1>
            <h3>{book.title}</h3>
            <img width="300" height="300" src={book.imagePath}></img>
            <div style={{ display: 'flex' }}>
                <ModalButton
                    btnName={'Взять книгу'}
                    title={'Взять книгу'}
                    modalContent={
                        <div>
                            <h1>Название</h1>
                            <h3>{book.title}</h3>
                            <h1>ISBN</h1>
                            <h3>{book.isbn}</h3>
                            <h1>Жанр</h1>
                            <h3>{book.genre}</h3>
                            <h1>Описание</h1>
                            <h3>{book.description}</h3>
                            <h1>В наличии</h1>
                            <h3>{book.count}</h3>
                            <h1> Дата возврата </h1>
                            <div style={{ margin: '10px' }}>
                                <DatePicker
                                    id="returnTime"
                                    selected={returnTime}
                                    dateFormat='dd/MM/yyyy'
                                    isClearable
                                    placeholderText={returnTime}
                                    onChange={e => setReturnTime(e)}
                                />
                            </div>

                            <button onClick={() => takeAction(book.id, returnTime)}>Взять книгу</button>
                        </div>
                    } />
            </div>
        </div>
    )
}
export default Home;