import { useEffect, useState } from "react";
import ModalButton from "./ModalBtn";
import 'react-datepicker/dist/react-datepicker.css';
import DatePicker from 'react-datepicker';
import { getAuthors, addAuthor, updateAuthor, deleteAuthor }  from '../services/AuthorService';


const URL = `api/author`;

const Authors = () => {
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [country, setCountry] = useState('');
    const [dateOfBirth, setdateOfBirth] = useState('');

    const [allAuthors, setAuthors] = useState([]);


    useEffect(() =>
    {
        const fetchAuthors = async () => {
            const authors = await getAuthors();
            setAuthors(authors); 
        };

        fetchAuthors();
    }, [])

    return (
        <div>
            <div>
                <p>Добавление автора</p>
                <p>Имя</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={name} onChange={e => setName(e.target.value)} />
                </div>
                <p>Фамилия</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={surname} onChange={e => setSurname(e.target.value)} />
                </div>
                <p>Страна</p>
                <div style={{ margin: '10px' }}>
                    <input type="text" value={country} onChange={e => setCountry(e.target.value)} />
                </div>
                <p>Дата рождения</p>
                <DatePicker
                    selected={dateOfBirth}
                    onChange={date => setdateOfBirth(date)}
                    dateFormat='dd/MM/yyyy'
                    isClearable
                    placeholderText='Выберите дату'
                />

                <button onClick={() => addAuthor(name, surname, country, dateOfBirth)}>Добавить автора</button>
            </div>
            <div>
                {allAuthors.map(x => <PostItem key={x.id} author={x} deleteAction={deleteAuthor} updateAction={updateAuthor} />)}
            </div>
        </div>
    )
}

export default Authors;


const PostItem = ({ author, deleteAction, updateAction }) => {

    return (
        <div style={{ backgroundColor: 'whitesmoke', margin: '10px', borderRadius: '10px', padding: '10px' }}>
            <h1>Имя</h1>
            <h3>{author.name}</h3>
            <h1>Фамилия</h1>
            <h3>{author.surname}</h3>
            <div style={{ display: 'flex' }}>
                <button onClick={() => deleteAction(author.id)}>Удалить</button>
                <ModalButton
                    btnName={'Изменить'}
                    title={'Изменить данные автора'}
                    modalContent={
                        <div>
                            <h1>Имя</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="name"
                                    defaultValue={author.name}
                                    onChange={e => author.name = e.target.value}
                                />
                            </div>
                            <h1>Фамилия</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="surname"
                                    defaultValue={author.surname}
                                    onChange={e => author.surname = e.target.value}
                                />
                            </div>
                            <h1>Страна</h1>
                            <div style={{ margin: '10px' }}>
                                <input type="text" id="country"
                                    defaultValue={author.country}
                                    onChange={e => author.country = e.target.value}
                                />
                            </div>

                            <h1> Дата рождения </h1>
                            <div style={{ margin: '10px' }}>
                                <DatePicker
                                    id="dateOfBirth"
                                    selected={author.dateOfBirth}
                                    dateFormat='dd/MM/yyyy'
                                    isClearable
                                    placeholderText={author.dateOfBirth}
                                    onChange={e => author.dateOfBirth = e.target.value}
                                />
                            </div>

                            <button onClick={() => updateAction(author)}>Изменить данные автора</button>
                        </div>
                    } />
            </div>
        </div>
    )
}