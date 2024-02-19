import React from 'react'
import { useNavigate } from 'react-router-dom';

export default function Nav(props){
    const navigate = useNavigate();
    return (
        <div className='nav'>
                <img src={`../../images/${props.imgSrc}`} alt="user profile" className="profile"/>
                <p>{props.status}</p>
                <div className='nav--inner'>
                    <div onClick={props.create}>
                        <img  className="icon" src="../../images/create-icon-removebg-preview.png" alt=" "/>
                        Create Itinerary
                    </div>
                    <div onClick={props.view}>
                        <img  className="icon" src="../../images/view-icon.png" alt=" " />
                        View Itinerary
                    </div>
                    <div onClick={props.setting}>
                        <img  className="icon" src="../../images/setting-icon-removebg-preview.png" alt=" "/>
                        Settings
                    </div>
                    <button className="nav--button" onClick={() => {
                        navigate('/login')
                        localStorage.setItem('loggedIn', false)
                        localStorage.removeItem('img')
                        localStorage.removeItem('user')
                        }}>
                        {props.name}</button>
                </div>
                
        </div>
    )
}