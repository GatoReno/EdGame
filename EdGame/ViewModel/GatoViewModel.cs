 
using System.Collections.ObjectModel; 
using System.Windows.Input;  

namespace EdGame.ViewModels;
public class GatoViewModel : BindableObject
{

    private string[] _board;  // El tablero de 3x3 representado como un arreglo de cadenas
    private string? _currentPlayer; // Jugador actual ("X" o "O")
    private string? _gameStatus; // Estado del juego: "En juego", "Ganador", "Empate"
    private UserModel? _player1;  // Usuario 1
    private UserModel? _player2;  // Usuario 2
    private UserModel? _currentUser;  // Jugador actual

    public ObservableCollection<UserModel> Users { get; set; }

 
    public ICommand MakeMoveCommand { get; private set; }   
    
    public GatoViewModel()
    {
        Users = new ObservableCollection<UserModel>();
        
        MakeMoveCommand = new Command<string>(MakeMove);
        _board = new string[9]; // Inicializa el tablero de 9 espacios
        ResetGame();
    }


    // Propiedad para el tablero
    public string[] Board
    {
        get => _board;
        set
        {
            _board = value;
            OnPropertyChanged();
        }
    }

    // Propiedad para el estado del juego
    public string? GameStatus
    {
        get => _gameStatus;
        set
        {
            _gameStatus = value;
            OnPropertyChanged();
        }
    }

    // Propiedad para el jugador actual
    public UserModel? CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            OnPropertyChanged();
        }
    }

    // Método para configurar los jugadores (puedes llamar este método desde la vista)
    public void SetPlayers(UserModel player1, UserModel player2)
    {
        _player1 = player1;
        _player2 = player2;
        CurrentUser = _player1; // El primer jugador comienza
    }

    // Método para realizar un movimiento
    public void MakeMove(string _index)
    {
        int index = int.Parse(_index);
        if (_board[index] == null && _gameStatus == "En juego")  // Si la celda está vacía y el juego está en curso
        {
            _board[index] = _currentPlayer!;

            // Verifica si hay un ganador
            if (CheckWinner())
            {
                GameStatus = $"{CurrentUser?.Name} ha ganado!";
            }
            else if (_board.All(cell => cell != null))  // Si no hay más espacios vacíos
            {
                GameStatus = "Empate!";
            }
            else
            {
                // Cambiar de turno
                _currentPlayer = _currentPlayer == "X" ? "O" : "X";
                CurrentUser = CurrentUser == _player1 ? _player2 : _player1;
            }

            OnPropertyChanged(nameof(Board));
        }
    }

    // Verificar si hay un ganador
    private bool CheckWinner()
    {
        // Condiciones de victoria
        var winPatterns = new[]
        {
            new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 }, // Filas
            new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 }, // Columnas
            new[] { 0, 4, 8 }, new[] { 2, 4, 6 }  // Diagonales
        };

        foreach (var pattern in winPatterns)
        {
            if (_board[pattern[0]] == _board[pattern[1]] && _board[pattern[1]] == _board[pattern[2]] && _board[pattern[0]] != null)
            {
                return true;
            }
        }

        return false;
    }

    // Método para resetear el juego
    public void ResetGame()
    { 
        SetPlayers(new UserModel { Name = "x" }, new UserModel { Name = "x" });
        _board = new string[9];
        _currentPlayer = "X";  // El jugador "X" comienza
        _gameStatus = "En juego";
        CurrentUser = _player1;
        OnPropertyChanged(nameof(Board));
        OnPropertyChanged(nameof(GameStatus));
    }

  
}
