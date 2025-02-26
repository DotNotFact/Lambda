import Header from './header/Header.tsx'

const Layout = ({ children }: Props) => {
	return (
		<div>
			<Header />
			{children}
		</div>
	)
}

export default Layout

interface Props {
	children: React.ReactNode
}
