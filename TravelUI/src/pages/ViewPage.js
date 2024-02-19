import React from 'react'
import { useLocation} from "react-router-dom";
import Header from '../components/Header';

export default function ViewPage(){
    const location = useLocation()

    return(
        <>
            <Header />
            <div className='viewPage'>
                <h1>{location.state.title}</h1>
                <div className='viewPage--inner'>
                    <img className='viewPage--image' src={`../../images/${location.state.img}`} />
                    <p className='text-style'>{location.state.shortDes}</p>
                </div>
                <p className='text-style'>{location.state.longDes}</p>
                <a href={location.state.link}>more</a>
            </div>
        </>
    );
}