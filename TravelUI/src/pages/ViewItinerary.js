import React, {useState, useEffect} from 'react'
import {useNavigate, useLocation} from "react-router-dom"
import Header from '../components/Header'

export default function ViewItinerary(){
    const location = useLocation()
    const [data, setData] = useState([])
    const [filteredData, setFilteredData] = useState([])

    useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/itinerary`)
        const data = await res.json()
          setData(data)
          
        }
        fetchCard().catch((error) => console.error(error));
      }, []);
      console.log(data)
      useEffect(() => {
      setFilteredData(data.filter((item)=>item.userId === location.state.id));
    })
    console.log(location.state.id)
    console.log(filteredData)
        const myItineraries = filteredData.map(item => {
        return (
            <div className='block' key={item.id}>
                <p className='block--title'>{item.name}</p>
                <div className='block-inner'>
                    <img src={`../../images/${item.img}`} className='block--image'/>
                    <div className='block-innerMost'>
                    <p className='block--descrption'>Created By: </p>
                    <label>Attractions</label>
                    <label>Events</label>
                    </div>
                </div>
            </div>
        )
        })

    return(
        <>
        <Header />
        <div className='os-box'>
            <div className='heading2'>
                <h2 className='card-title'>My Itineraries</h2>
            </div>
            <section className='os-list'>
                {myItineraries}
            </section>
        </div>
        </>
    )
}