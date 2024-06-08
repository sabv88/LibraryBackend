import { useEffect, useState } from "react";
import ModalButton from "./ModalBtn";
import 'react-datepicker/dist/react-datepicker.css';
import DatePicker from 'react-datepicker';
import userManager, { loadUser } from '../auth/user-service.ts';


const URL = `api/book`;

const Books = () =>
{
    const [title, setTitle] = useState('');
    const [isbn, setIsbn] = useState('');
    //const [imagePath, setImagePath] = useState('');
    const [count, setCount] = useState(0);
    const [genre, setGenre] = useState('');
    const [description, setDescription] = useState('');
    const [selectedImage, setSelectedImage] = useState(null);
    const [selectedImageFile, setSelectedImageFile] = useState(null);

    const [author, setAuthor] = useState(null);

    const [allBooks, setBooks] = useState([]);

    const getBooks = async () =>
    {
        const options = {
            method: 'GET',
            headers: new Headers()
        }
        const result = await fetch(URL, options);
        console.log(result);
        if (result.ok)
        {
            const books = await result.json();
            console.log(books.books);
            
            setBooks(books.books);
            return books.books;
        }
        return [];
    }

    const addBook = async () =>
    {
        const imagePath = await ImageUpload();
        console.log(imagePath);
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

        const result = await fetch(URL, options);
        console.log(result);

        if (result.ok)
        {
            allBooks.push(await result.json());
            setBooks(allBooks);
        }
    }

    const updateBook = async (oldBook) =>
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

        const result = await fetch(URL, options);
        if (result.ok) {
            const book = await result.json();
            const updatedBook = allBooks.findIndex(x => x.id === oldBook.id);
            allBooks[updatedBook] = book;
            setBooks(allBooks.slice());
        }
    }

    const deleteBook = async (id) =>
    {
        await loadUser();
        const headers = new Headers();
        headers.set('Content-Type', 'application/json');
        const token = localStorage.getItem('token');
        headers.set('Authorization', 'Bearer ' + token);
        const options = {
            method: 'DELETE',
            headers: headers
        }
        fetch(URL + `/${id}`, options);
        setBooks(allBooks.filter(x => x.id !== id));
    }

    const handleImageUpload = async (event) =>
    {
        const file = event.target.files[0];
        const reader = new FileReader();

        reader.onloadend = () =>
        {
            setSelectedImage(reader.result);
        };

        if (file)
        {
            setSelectedImageFile(file);
            reader.readAsDataURL(file);
        }
        else
        {
            setSelectedImage(null);
        }
    };

    const ImageUpload = async () =>
    {
        if (selectedImage != null)
        {
            const formData = new FormData();
            formData.append('FormFile', selectedImageFile);

            const headers = new Headers();
            headers.set('Content-Type', 'application/json');
            const options =
            {
                method: 'POST',
                body: formData
            };
            console.log(formData);
            console.log(options);

            const result = await fetch('/api/file', options);
            if (result.ok)
            {
                console.log(result);
                const path = await result.json();
                console.log(path);
                return await path;
            }
            console.log(result);
            return result.path;
        }
        else
        {
            return null;
        }
    };

    useEffect(() => {
        getBooks();
    }, [])

    return (
        <div>
            <div>
                <p>Добавление книги</p>
                <p>ISBN</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={isbn} onChange={e => setIsbn(e.target.value)} />
                </div>
                <p>Название</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={title} onChange={e => setTitle(e.target.value)} />
                </div>
                <p>Жанр</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={genre} onChange={e => setGenre(e.target.value)} />
                </div>
                <p>Описание</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={description} onChange={e => setDescription(e.target.value)} />
                </div>
                <p>Количество</p>
                <div style={{ margin: '10px' }}>
                    <input type="number" value={count} onChange={e => setCount(e.target.value)} />
                </div>
                <p>Путь изображения</p>
                <div>
                    <input type='file' accept='image/*' onChange={handleImageUpload} />
                </div>

                 <div>
                    <img src={selectedImage} alt='Выбранное изображение' />
                </div>
             

                <button onClick={() => addBook()}>Добавить книгу</button>
            </div>
            <div>
                {allBooks.map(x => <PostItem key={x.id} book={x} deleteAction={deleteBook} updateAction={updateBook} handleImageUpload={handleImageUpload } />)}
            </div>
        </div>
    )
}

export default Books;


const PostItem = ({ book, deleteAction, updateAction }) =>
{

    return (
        <div style={{ backgroundColor: 'whitesmoke', margin: '10px', borderRadius: '10px', padding: '10px' }}>
            <h1>Название</h1>
            <h3>{book.title}</h3>
            <img width="300" height="300" src={book.imagePath}></img>
            <div style={{ display: 'flex' }}>
                <button onClick={() => deleteAction(book.id)}>Удалить</button>
                <ModalButton
                    btnName={'Изменить'}
                    title={'Изменить книгу'}
                    modalContent={
                        <div>
                            <h1>ISBN</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="isbn"
                                    defaultValue={book.isbn}
                                    onChange={e => book.isbn = e.target.value}
                                />
                            </div>
                            <h1>Название</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="title"
                                    defaultValue={book.title}
                                    onChange={e => book.title = e.target.value}
                                />
                            </div>
                            <h1>Жанр</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="genre"
                                    defaultValue={book.genre}
                                    onChange={e => book.genre = e.target.value}
                                />
                            </div>
                            <h1>Описание</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="description"
                                    defaultValue={book.description}
                                    onChange={e => book.description = e.target.value}
                                />
                            </div>
                            <h1>Количество</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="number" id="count"
                                    defaultValue={book.count}
                                    onChange={e => book.count = e.target.value} />
                            </div>
                            <h1>ImagePath</h1>
                            <div>
                                {/*<input type='file' accept='image/*' onChange={handleImageUpload} />*/}
                            {/*    <img src={selectedImage} alt='Выбранное изображение' />*/}
                            </div>


                            <button onClick={() => updateAction(book)}>Изменить книгу</button>
                        </div>
                    } />
            </div>
        </div>
    )
}