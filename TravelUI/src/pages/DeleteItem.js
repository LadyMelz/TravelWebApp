import React from 'react'
import Popup from 'reactjs-popup';
import { useNavigate, useLocation } from 'react-router-dom'

export default function DeleteItem(){
    const navigate = useNavigate()
    const location = useLocation()
    function confirmDelete(){
    try {
        fetch(`https://localhost:7046/api/${location.state.buttonPressed}/${location.state.id}`, {
        method: 'delete',
        header: {
            'Content-Type': 'application/problem+json; charset=utf-8'
        }
         })
        navigate('/')
         
    } catch (error) {
        console.error('An error occurred', error);
    }
    console.log("deleting...")
  }
  return(
    <>
    <Popup trigger={location.state.flag} position="top">
            <div>
                <p>Are you sure you want to delete this {location.state.buttonPressed}?</p>
                <span className="form-link" onClick={confirmDelete}>Yes</span>
                <span className="form-link" onClick={()=> navigate(-1)}>No</span>
            </div>
    </Popup>
    </>
  )
}