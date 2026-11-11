package com.example.logismartmobile

object DadosSimulados {

    // Usuário fictício para demonstração do aplicativo
    val usuarios = listOf(
        Usuario(
            id = 1,
            nome = "Motorista Demonstração",
            email = "motorista@logismart.com",
            senha = "123456",
            perfil = "Motorista"
        )
    )

    // Clientes baseados nos registros do banco LogiSmart
    val clientes = listOf(
        Cliente(
            id = 1,
            nome = "Joao Silva",
            email = "joao@email.com",
            telefone = "11999990001",
            endereco = "Rua A, 100"
        ),

        Cliente(
            id = 2,
            nome = "Maria Souza",
            email = "maria@email.com",
            telefone = "11999990002",
            endereco = "Rua B, 200"
        ),

        Cliente(
            id = 3,
            nome = "Carlos Oliveira",
            email = "carlos@email.com",
            telefone = "11999990003",
            endereco = "Rua C, 300"
        )
    )

    // Entregas fictícias para demonstração
    val entregas = listOf(
        Entrega(
            id = 101,
            cliente = "Joao Silva",
            endereco = "Rua A, 100",
            status = "Em andamento"
        ),

        Entrega(
            id = 102,
            cliente = "Maria Souza",
            endereco = "Rua B, 200",
            status = "Pendente"
        ),

        Entrega(
            id = 103,
            cliente = "Carlos Oliveira",
            endereco = "Rua C, 300",
            status = "Concluído"
        )
    )
}