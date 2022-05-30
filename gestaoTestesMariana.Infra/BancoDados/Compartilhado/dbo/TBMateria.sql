CREATE TABLE [dbo].[TBMateria]
(
	[Numero] INT NOT NULL PRIMARY KEY, 
    [Nome_Materia] NCHAR(10) NULL, 
    [Disciplina] VARCHAR(50) NOT NULL

	CONSTRAINT [FK_TBDisciplina] FOREIGN KEY ([Disciplina]) REFERENCES [dbo].[TBDisciplina] ([Nome])
)
