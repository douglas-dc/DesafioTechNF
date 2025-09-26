Projeto criado conforme as necessidades solicitadas.

Obs1: Foi utilizado o banco de dados SQLite no desenvolvimento;
Obs2: CRUD completo somente para a entidade Aluno, o restante foi desenvolvido somente o necessário para o funcionamento da aplicação.

---SCRIPTS---

CREATE TABLE Alunos (
    Id      TEXT PRIMARY KEY,
    Nome    TEXT NOT NULL,
    Plano   INTEGER NOT NULL CHECK (Plano IN (0, 1, 2))
);

CREATE TABLE Aulas (
    Id               TEXT PRIMARY KEY, 
    Modalidade       TEXT NOT NULL,    
    Horario          DATETIME NOT NULL,
    CapacidadeMaxima INTEGER NOT NULL CHECK (CapacidadeMaxima > 0)
);

CREATE TABLE Agendamentos (
    Id          TEXT PRIMARY KEY, -- GUID
    AlunoId     TEXT NOT NULL,
    AulaId      TEXT NOT NULL,
    DataCriacao DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (AlunoId) REFERENCES Aluno(Id) ON DELETE CASCADE,
    FOREIGN KEY (AulaId) REFERENCES Aula(Id) ON DELETE CASCADE,

    UNIQUE (AlunoId, AulaId)
);
