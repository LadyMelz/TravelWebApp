import React,{useState, useEffect} from 'react'
import Block from './Block'


export default function OrderSummary(props){
  const [data, setData] = useState([]);
  const [block, setBlock] = useState([]);

    if (props.title === "Attractions"){
        var path = 'attraction'
      } else path = 'event'
     
      useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/${path}`)
        const data = await res.json()
          setData(data)
          setBlock(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);

      function search(event){
        setBlock(data.filter((item)=>item.title.toLocaleLowerCase().includes(event.target.value)));
      }
  
    const blocks = block.map(item => {
        return <Block key={item.id} img={item.imgURL} {...item}/>
    })
    return(
        <div className='os-box'>
            <div className='heading2'>
            <h2 className='card-title'>{props.title}</h2>
            <div className="searchBox">
                    <input className="searchInput" type="text"  placeholder="Search" onKeyUp={search}/>
                    <button className="searchButton">
                        <img className="icons" src="../../images/search-icon.png" alt=" "/>
                    </button>
        
                </div>
            </div>
            <section className='os-list'>
                {blocks}
            </section>
        </div>
    )
}