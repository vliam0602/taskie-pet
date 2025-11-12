import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import { weatherService } from './services/exampleService';


export interface Weather {
  date: string;
  temperatureC: number;
  summary: string;
  temperatureF: number;
};

function App() {
  const [count, setCount] = useState(0);

  const [weather, setWeather] = useState<Weather[]>([]);
  // const [loading, setLoading] = useState(true);

  useEffect(() => {
    const loadWeather = async () => {
      try {
        const data = await weatherService.getWeather();
        setWeather(data);
      } catch (error) {
        console.error("Failed to load weather: ", error);
      }
      // finally {
      //   setLoading(false);
      // } 
    };
    loadWeather();    
  }, []);

  // if (loading) return <p>Loading weather...</p>;
  // if (weather.length === 0) return <p>No weather found.</p>;

  return (
    <>
      <div>
        <a href="https://vite.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>Vite + React</h1>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        <p>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>

      {/* test loading data from api */}      
      <ul>
        {weather.map(((w) => (
          <li>
            {w.date}: {w.temperatureC} C; {w.temperatureF} F ({w.summary})
          </li>
        )))}
      </ul>
    </>
  )
}

export default App
