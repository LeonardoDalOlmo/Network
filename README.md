# Network
 
Uma biblioteca em C# para gerenciamento de conjunto de elementos que permite conectar, desconectar e verificar conexões entre elementos de uma rede, utilizando busca em largura (BFS) para navegação entre elementos.
 
## 🛠️ Tecnologias Utilizadas
 
- **Linguagem:** C#
- **Plataforma:** .NET
- **Algoritmo:** Busca em Largura (BFS)


## 📦 Como Instalar
 
### Pré-requisitos
 
- [.NET SDK](https://dotnet.microsoft.com/download) instalado
### Passos
 
1. Clone ou baixe os arquivos do projeto:
   ```bash
   git clone git@github.com:LeonardoDalOlmo/Network.git
   ```
 
2. Certifique-se de que os arquivos `Conjunto.cs` e `Program.cs` estão no mesmo diretório.
3. Compile o projeto:
   ```bash
   dotnet build
   ```
 
## ▶️ Como Usar
 
### Executando o projeto
 
```bash
dotnet run
```
 
### Exemplo de uso no código
 
```csharp
// Cria uma rede com 10 elementos
Conjunto conj = new Conjunto(10);
 
// Conecta elementos
conj.Conectar(1, 2);
conj.Conectar(2, 8);
 
// Verifica se dois elementos estão conectados (direto ou indiretamente)
bool conectados = conj.VerificarConexao(1, 8); // true
 
// Verifica o nível (distância) entre dois elementos
int nivel = conj.NivelConexao(1, 8); // 2
 
// Desconecta elementos
conj.Desconectar(1, 2);
```
 
### Métodos disponíveis
 
| Método | Descrição |
|---|---|
| `Conjunto(int qtde)` | Cria uma rede com `qtde` elementos |
| `Conectar(int a, int b)` | Conecta dois elementos |
| `Desconectar(int a, int b)` | Remove a conexão entre dois elementos |
| `VerificarConexao(int a, int b)` | Retorna `true` se há caminho entre os elementos |
| `NivelConexao(int a, int b)` | Retorna a distância mínima entre os elementos |
