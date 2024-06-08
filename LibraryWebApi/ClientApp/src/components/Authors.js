import { useEffect, useState } from "react";
import ModalButton from "./ModalBtn";
import 'react-datepicker/dist/react-datepicker.css';
import DatePicker from 'react-datepicker';
import userManager, { loadUser, signinRedirect, signoutRedirect } from '../auth/user-service.ts';


const URL = `api/author`;

const Authors = () => {
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [country, setCountry] = useState('');
    const [dateOfBirth, setdateOfBirth] = useState('');

    const [allAuthors, setAuthors] = useState([]);

    const getAuthors = async () =>
    {
        await loadUser();
        const headers = new Headers();
        headers.set('Content-Type', 'application/json');
        const token = localStorage.getItem('token');
        headers.set('Authorization', 'Bearer ' + token);
        const options = {
            method: 'GET',
            headers: headers
        }
        const result = await fetch(URL, options);
        console.log(result);
        if (result.ok) {
            const authors = await result.json();
            console.log(authors.authors);

            setAuthors(authors.authors);
            return authors.authors;
        }
        return [];
    }

    const addAuthor = async () =>
    {
        const author = { surname, name, country, dateOfBirth };
        console.log(author);
        await loadUser();
        const headers = new Headers();
        headers.set('Content-Type', 'application/json');
        const token = localStorage.getItem('token');
        headers.set('Authorization', 'Bearer ' + token);
        const options =
        {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(author)
        };

        const result = await fetch(URL, options);
        console.log(result);

        if (result.ok)
        {
            allAuthors.push(await result.json());
            setAuthors(allAuthors);
        }
    }

    const updateAuthor = async (oldAuthor) =>
    {
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

        const result = await fetch(URL, options);
        if (result.ok) {
            const author = await result.json();
            const updatedAuthor = allAuthors.findIndex(x => x.id === oldAuthor.id);
            allAuthors[updatedAuthor] = author;
            setAuthors(allAuthors.slice());
        }
    }

    const deleteAuthor = async (id) =>
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
        setAuthors(allAuthors.filter(x => x.id !== id));
    }

    useEffect(() => {
        getAuthors();
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

                <button onClick={() => addAuthor()}>Добавить автора</button>
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