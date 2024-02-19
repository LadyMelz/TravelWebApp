import React from 'react'
import Header from '../components/Header'
//import Hero from '../components/Hero'
import Footer from '../components/Footer'
import Cards from '../components/Cards'
import Nav from '../components/Nav'
import {useNavigate, useLocation} from "react-router-dom"
import Itinerary from '../components/Itinerary'


function Profile() {
    const location = useLocation()
    const navigate = useNavigate()
    function create(){
      navigate('/create', {
        state: {
            id : location.state.id
            }
        })
    }
    function view(){
      navigate('/view', {
        state: {
            id : location.state.id
            }
        })
    }
    function setting(){
      navigate('/settings', {
        state: {
            id : location.state.id
            }
        })
    }
  return (
    <>
    <Header/>
      <div className='container'>
        <div>
          <Nav 
            imgSrc={location.state.img} 
            status="online" 
            name="Log Out" 
            create={create}
            view={view}
            setting={setting}/>
        </div>
        <div className='container--main'>
            <Itinerary/>
            <Cards title="Attractions"/>
            <Cards title="Events"/>
          </div>
      </div>
      <Footer />
    </>

    
  );
}

export default Profile;
