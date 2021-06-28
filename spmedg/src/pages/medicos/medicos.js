import { React, Component } from 'react';


class medicos extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [],
            idEspecialidade : 2,
            nomeEspecialidade: '',
        }
    }

    buscarConsultas = () => {
        console.log(this.state.idEspecialidade)

        // Chamando a API com o fetch
        fetch( 'http://localhost:5000/api/especialidades' )

        // Define o tipó de retorno (JSON)
        .then(resposta => resposta.json())

        // Atualiza a lista
        .then(data => this.setState({listaConsultas : data}))

        // Caso ocorra algum erro, mostrar ele no console
        .catch((erro) => console.log (erro))
    }

    componentDidMount(){
        this.buscarConsultas();
    }

    render(){
        return(
            <div>
                <main>
                    <section>
                        {/* {Lista de consultas médico} */}
                        <h2>Consultas</h2>
                            <table>
                                <thead>
                                    <tr>
                                        <th>id</th>
                                        <th>Titulo</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {   
                                        this.state.listaConsultas.map( (consulta) => {
                                            return(
                                                <tr key={consulta.idEspecialidade}>
                                                    <td>{consulta.idEspecialidade}</td>
                                                    <td>{consulta.nomeEspecialidade}</td>
                                                </tr>
                                            )
                                        } )
                                    } 
                                </tbody>
                            </table>
                    </section>
                </main>
            </div>
        );
    }
}

export default medicos;