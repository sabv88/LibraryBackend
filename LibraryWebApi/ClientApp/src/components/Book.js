import { useEffect, useState } from "react";
import ModalButton from "./ModalBtn";
import 'react-datepicker/dist/react-datepicker.css';
import DatePicker from 'react-datepicker';
import { getBooks, addBook, updateBook, deleteBook } from '../services/BookService';

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

    const [allBooks, setBooks] = useState([]);

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

 

    useEffect(() => {
        const fetchBooks = async () => {
            const books = await getBooks();
            setBooks(books);
        };

        fetchBooks();
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
             

                <button onClick={() => addBook(isbn, title, genre, description, count, selectedImageFile)}>Добавить книгу</button>
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