import React, {useState, useEffect} from 'react'
export default function Itinerary(){
    const [itinerary, setItinerary] = useState([])
    const userName = []
    useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/Itinerary`)
        const data = await res.json()
          setItinerary(data)
          console.log(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);


      async function fetchName() {
        for(var i of itinerary){
            try {
                const response = await fetch(`https://localhost:7046/api/User/${i.userId}`)
                const data = await response.json()
                  userName.push(data.fullName)
               
                
        
            } catch (error) {
                console.error('An error occurred', error);
            }
      
      }
      }
      //console.log(userName)
      //fetchName()
      const itineraries = itinerary.map((item) => {
        console.log(userName[1])
        return (
          <div key={item.id} className='itinerary'>
                  <p className='icard--title'>{item.name}</p>
                  <img src={`../../images/${item.img}`} className='itinerary--image'/>
                  <p className='icard--title'>By: </p>
              </div>
        )})
      
      
    return(
        <div className="card-box">
          <h2 className="card-title">Itineraries</h2>
          <section className="itinerary-list">
            {itineraries}
          </section>
        </div>
    )
}