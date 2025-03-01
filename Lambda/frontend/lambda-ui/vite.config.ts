import tsconfigPaths from 'vite-tsconfig-paths'
import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
	plugins: [react(), tsconfigPaths()],
	css: {
		preprocessorOptions: {
			scss: {
				api: 'legacy',
				includePaths: ['src/assets/styles'],
				silenceDeprecations: ['legacy-js-api']
			}
		}
	},
	resolve: {
		alias: {
			'@/*': 'src/assets/*'
		}
	}
})
