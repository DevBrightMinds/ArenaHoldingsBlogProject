import React from "react";
import { Link } from "react-router-dom";

import $ from "jquery";

const NavBar: React.FC<{}> = (): JSX.Element => {
    const toggleMenu = () => {
        $(".app-nav").slideToggle(500);
    }
    return <>
        <header style={ModalStyle.header}>
            <div className="nav-mobile" onClick={toggleMenu}>
                <div className="bar" style={ModalStyle.mobileMenuBar}></div>
                <div className="bar" style={ModalStyle.mobileMenuBar}></div>
                <div className="bar" style={ModalStyle.mobileMenuBar}></div>
            </div>
            <div className="app-header" style={ModalStyle.appHeader}>
                <div className="app-name" style={ModalStyle.appName}>
                    Articles
                </div>
                <div className="app-nav" style={ModalStyle.appNavi}>
                    <Link to="/">Home</Link>
                    <Link to="/contact">Contact</Link>
                </div>
            </div>
        </header>
    </>
}

const ModalStyle = {
    header: {
        backgroundColor: "whitesmoke",
        padding: 30,
        width: "100%",
        color: "#333333",
        boxShadow: "1px 1px 1px #cccccc"
    },
    appHeader: {
        width: "80%",
        margin: "0 auto",
        display: "flex",
    },
    appName: {
        width: "30%",
    },
    appNavi: {
        width: "70%",
    },
    mobileMenuBar: {
        backgroundColor: "#333333",
        width: "20px",
        height: "1px",
        padding: 1,
        margin: 2
    }
}

export default NavBar;