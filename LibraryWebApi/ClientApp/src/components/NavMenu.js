import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import userManager, { loadUser, signinRedirect, signoutRedirect } from '../auth/user-service.ts';

import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;
    static auth;
    constructor(props) {
        super(props);
        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true,
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        const role = localStorage.getItem('role');

        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                    <NavbarBrand tag={Link} to="/">LibraryWebApi</NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                            </NavItem>

                            <NavItem>
                                <NavLink tag={Link} className="text-dark" to="/user">Taken books</NavLink>
                            </NavItem>

                            {role === 'admin' && (
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/author">AuthorAdmin</NavLink>
                                </NavItem>
                            )}

                            {role === 'admin' && (
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark" to="/Book">BookAdmin</NavLink>
                                </NavItem>
                            )}

                            <NavItem>
                                <button onClick={() => signoutRedirect()}>Logout</button>
                            </NavItem>

                            <NavItem>
                                <button onClick={() => signinRedirect()}>Login</button>
                            </NavItem>
                        </ul>
                    </Collapse>
                </Navbar>
            </header>
        );
    }
}

//import React, { Component } from 'react';
//import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
//import { Link } from 'react-router-dom';
//import userManager, { loadUser, signinRedirect, signoutRedirect } from '../auth/user-service.ts';

//import './NavMenu.css';

//export class NavMenu extends Component {
//    static displayName = NavMenu.name;
//    constructor(props) {
//        super(props);
//        this.toggleNavbar = this.toggleNavbar.bind(this);
//        this.state = {
//            collapsed: true,
//            showAdminBoard: false,
//            currentUser: false,
//        };
//    }
//    componentDidMount() {
//        const token = localStorage.getItem('token');
//        const role = localStorage.getItem('token');
//        console.log(token);
//        console.log(role);

//        if (!token & token != '') {
//            this.setState({
//                currentUser: true,
//            });
//        }
//        if (!role & role != '') {
//            this.setState({
//                showAdminBoard: true,
//            });
//        }
//    }

//    toggleNavbar() {

//        this.setState({
//            collapsed: !this.state.collapsed
//        });
//    }

//    render() {
//        const { currentUser, showAdminBoard } = this.state;

//        return (
//            <header>
//                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
//                    <NavbarBrand tag={Link} to="/">LibraryWebApi</NavbarBrand>
//                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
//                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
//                        <ul className="navbar-nav flex-grow">
//                            {showAdminBoard && (
//                                <NavItem>
//                                    <NavLink tag={Link} className="text-dark" to="/author">AuthorAdmin</NavLink>
//                                </NavItem>
//                            )}
//                            {showAdminBoard && (
//                                <NavItem>
//                                    <NavLink tag={Link} className="text-dark" to="/Book">BookAdmin</NavLink>
//                                </NavItem>
//                            )}
//                            {currentUser && (
//                                <NavItem>
//                                    <NavLink tag={Link} className="text-dark" to="/User">Taken books</NavLink>
//                                </NavItem>
//                            )}

//                            {currentUser ? (
//                                <NavItem>
//                                    <button onClick={() => signoutRedirect()}>Logout</button>
//                                </NavItem>
//                            ) : (
//                                <NavItem>
//                                    <button onClick={() => signinRedirect()}>Login</button>
//                                </NavItem>
//                            )}
//                            <NavItem>
//                                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
//                            </NavItem>

//                        </ul>
//                    </Collapse>
//                </Navbar>
//            </header>
//        );
//    }
//}
