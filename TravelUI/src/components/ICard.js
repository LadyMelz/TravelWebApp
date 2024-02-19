import React from 'react'
import { useNavigate } from "react-router-dom";

export default function ICard(props){

    const navigate = useNavigate();
 
    return(
    <div className='card' onClick={() => {
        navigate('/viewpage', {
        state: {
            img: props.img, 
            title: props.title,
            shortDes: props.short_Description,
            longDes: props.long_Description,
            link: props.link
            }
        });
      }}>
            <img src={`../../images/${props.img}`} className='card--image'/>
            <p className='icard--title'>{props.title}</p> 
        </div>
    )
}