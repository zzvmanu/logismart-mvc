package com.example.logismartmobile

data class Entrega(
    val id: Int,
    val cliente: String,
    val endereco: String,
    var status: String
)