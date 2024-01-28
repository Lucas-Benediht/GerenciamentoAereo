# Sistema de Gerenciamento Aéreo

## Descrição
🚧[Projeto em construção ]🚧
- Este projeto é um sistema de gerenciamento em C# que utiliza o banco de dados SQLite para armazenamento de dados relacionados aeroportos, passageiros e voos.

## Pré-requisitos
- Visual Studio ou outra IDE para C#.
- .NET Framework ou .NET Core.
- SQLite.

## Instalação
1. Clone ou faça o download deste repositório.
2. Abra o projeto na sua IDE (recomendado: Visual Studio).
3. Certifique-se de que o SQLite esteja instalado no seu sistema. Se não estiver, você pode baixá-lo em [sqlite.org](https://sqlite.org/download.html).
4. Compile o projeto.
5. Execute o aplicativo.

## Uso
- Execute o programa e siga as instruções do menu para pesquisar passageiros, aeroportos, voos ou criar novos passageiros.

## Componentes Principais
### Models
- **Aeroporto**: Representa um aeroporto com código e nome.
- **Passageiro**: Representa um passageiro com ID, nome completo e idade.
- **Voo**: Representa um voo com número, aeroporto de partida, aeroporto de destino, hora de partida e hora de chegada.

### Services
- **AeroportoService**: Provê métodos para obter informações de aeroportos do banco de dados SQLite.
- **PassageiroService**: Provê métodos para criar e obter informações de passageiros do banco de dados SQLite.
- **VooService**: Provê métodos para obter informações de voos do banco de dados SQLite.

### Main Program
- **Program.cs**: Contém a lógica principal do programa, incluindo a configuração dos serviços e a interação com o usuário por meio de um menu.

## Contribuindo
Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests ou abrir issues para relatar problemas ou sugerir melhorias.

## Licença
Este projeto está licenciado sob a [MIT License](LICENSE).

## Autor
- Lucas Benediht Caldeira
