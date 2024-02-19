import React from 'react'
import NavBar from './NavBar'

export default function Header(){
    return (
        <header className='header'>
            <img src="../../images/icon-removebg-preview.png" alt="company logo" className='header--logo'/>
            <div className="header-inner">
                <NavBar />
            </div>
        </header>
    )
}