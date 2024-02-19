import React from 'react'
import { useNavigate } from 'react-router-dom';

export default function Hero(){
    const navigate = useNavigate();
    return (
        <div className='hero'>
            <h1 className='hero--title'>Travel Ethiopia</h1>
            <p className='hero--text'>
                This project focuses on making a travel web app Ethiopia, 
                that focuses on Ethiopian attractions and events happening in the country. 
                The features it will provide will be tied to destinations, flights, hotels 
                and other travel services in Ethiopia. External API will also be closely 
                related with our country such as using Ethiopian Airlines API to track flight status, 
                schedules and routes of Ethiopian Airlines.
            </p>
            <button className='hero--button'onClick={() => navigate('login')}>Get Started</button>
        </div>
    )
}