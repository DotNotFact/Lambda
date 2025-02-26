import { createRoot } from 'react-dom/client'
import './assets/styles/index.scss'
import { StrictMode } from 'react'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render(
	<StrictMode>
		<App />
	</StrictMode>
)
