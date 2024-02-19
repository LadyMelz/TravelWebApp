import React, {useState, useEffect} from 'react'
import Popup from 'reactjs-popup';
import {useNavigate, useLocation} from "react-router-dom"

export default function Settings(){
    var flag = true
    var emailError = true
    var orginalEmail = ""
    const navigate = useNavigate()
    const location = useLocation()
    const id = JSON.parse(localStorage.getItem('user'))

    const [formData, setFormData] = useState([])

    useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/User/${id}`)
        const data = await res.json()
          setFormData(data)
          console.log(id)
          console.log(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);

     
    const [profileData, setProfileData] = useState([])

    useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/User`)
        const data = await res.json()
          setProfileData(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);

      function handleChange(event){
        const {name, value,} = event.target
        setFormData(prevFormData => ({
            ...prevFormData,
            [name]: value
        }))
        validateData()
      }

      function validateData(){
        console.log(orginalEmail)


        if (formData.email !== orginalEmail) {
            for(var user of profileData){
                if(formData.email === user.email){
                    flag = false
                    emailError = "Email address already exists"
                }
            }
        }
    }
    
    console.log(flag)

      async function handleSubmit(event) {
        event.preventDefault()
        if(flag === true){
            try {
                const response = await fetch(`https://localhost:7046/api/User/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
                });
        
                if (response.ok) {
                console.log('Form data submitted successfully');
                // You might want to handle success here, like showing a success message
                } else {
                console.error('Error submitting form data');
                // Handle the error scenario here, like showing an error message
                }
                navigate('/login')
            } catch (error) {
                console.error('An error occurred', error);
            }
        }else {
            alert(emailError)
        }
        
      }

       async function deleteAccount(){
        try {
            await fetch(`https://localhost:7046/api/User/${id}`, {
            method: 'options',
            header: {
                'Content-Type': 'application/problem+json; charset=utf-8'
            }
             })
             localStorage.setItem('loggedIn',JSON.stringify(false))
            localStorage.removeItem('user')
            localStorage.removeItem('img')
            navigate('/')
             
        } catch (error) {
            console.error('An error occurred', error);
        }
        console.log("deleting...")
      }

    return (
        <div className="form-outer">
        <div className="form-container">
        <form className="form" onSubmit={handleSubmit}>
            <img 
                src="../../images/setting-icon-removebg-preview.png" 
                alt="an icon which visually represents a setting" 
                className='header--logo'
            />
            <div className='setting-label'>
            <label>
                Full Name:
            </label>
            <input 
            type="text" 
            placeholder="Full Name"
            className="form--input"
            name="fullname"
            onChange={handleChange}
            value={formData.fullName}
            />
            </div>
            <div className='setting-label'>
            <label>
                Email:
            </label>
            <input 
                type="email" 
                placeholder="Email address"
                className="form--input"
                name="email"
                onChange={handleChange}
                value={formData.email}
            />
            </div>
            <div className='setting-label'>
            <label>
                Password:
            </label>
            <input 
                type="text" 
                placeholder="Password"
                className="form--input"
                name="password"
                onChange={handleChange}
                value={formData.password}
            />
            </div>
            <div className='setting-label'>
            <label>
                Phone Number:
            </label>
            <input 
                type="text" 
                placeholder="Phone Number"
                className="form--input"
                name="phone"
                onChange={handleChange}
                value={formData.phone}
            />
            </div>
            <button className="nav--button">Save Changes</button>
            <div className="form--links">
            <Popup trigger={<span className="form-link">Delete Account</span>} position="top">
                <div>
                    <p>Are you sure you want to delete your account?</p>
                    <span className="form-link" onClick={deleteAccount}>Yes</span>
                    <span className="form-link" onClick={()=> navigate(-1)}>No</span>
                </div>
            </Popup>
                <span className="form-link" onClick={()=> navigate(-1)}>Back</span>
            </div>
        </form>
        </div>
        </div>
    )
}