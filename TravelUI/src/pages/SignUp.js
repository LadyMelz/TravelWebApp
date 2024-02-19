import React, { useState, useEffect } from "react";
import { NavLink, useNavigate } from 'react-router-dom';

export default function SignUp() {
    const navigate = useNavigate();
    var flag = true
    var emailError = ""
    var passwordError = ""

    const [formData, setFormData] = useState({
        fullname: "",
        email: "",
        password: "",
        passwordConfirm: ""
    })
    const [validData, setValidData] = useState({
        fullname: "",
        email: "",
        password: "",
        phone: "09---",
        imgUrl: "default-profile.png"
    })

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
    }

    function validateData(){
        validData.fullname = formData.fullname
        for(var user of profileData){
            if(formData.email === user.email){
                flag = false
                emailError = "Email address already exists"
            }
        }
        if(flag === true){
            validData.email = formData.email
        }
        if(formData.password === formData.passwordConfirm){
            validData.password = formData.password
        } else {
            flag = false
            passwordError = "Password doesn't match"
        }
    }
    validateData()
    async function handleSubmit(event) {
        event.preventDefault()
        if(flag === true){
            try {
                const response = await fetch(`https://localhost:7046/api/User`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(validData),
                });
        
                if (response.ok) {
                console.log('Form data submitted successfully');
                navigate('/login')
                // You might want to handle success here, like showing a success message
                } else {
                console.error('Error submitting form data');
                // Handle the error scenario here, like showing an error message
                }
                
            } catch (error) {
                console.error('An error occurred', error);
            }
        }else {
            alert(emailError + " " + passwordError)
        }
        
    }
    return (
    <div className="form-outer">
    <div className="form-container">
    <form className="form" onSubmit={handleSubmit}>
        <img src="../../images/icon-removebg-preview.png" alt="company logo" className='header--logo'/>
        <input 
            type="text" 
            placeholder="Full Name"
            className="form--input"
            name="fullname"
            onChange={handleChange}
            value={formData.fullname}
        />
        <input 
            type="email" 
            placeholder="Email address"
            className="form--input"
            name="email"
            onChange={handleChange}
            value={formData.email}
        />
        <input 
            type="password" 
            placeholder="Password"
            className="form--input"
            name="password"
            onChange={handleChange}
            value={formData.password}
        />
        <input 
            type="password" 
            placeholder="Confirm Password"
            className="form--input"
            name="passwordConfirm"
            onChange={handleChange}
            value={formData.passwordConfirm}
        />
        <button>
            Sign Up
        </button>
        <div className="form--links">
            <NavLink to="/login">Back</NavLink>
            <NavLink to="/">Home</NavLink>
        </div>
    </form>
    </div>
    </div>
)
}