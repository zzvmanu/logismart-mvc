package com.example.logismartmobile

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class LoginActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)

        val edtEmail = findViewById<EditText>(R.id.edtEmail)
        val edtSenha = findViewById<EditText>(R.id.edtSenha)
        val btnEntrar = findViewById<Button>(R.id.btnEntrar)

        btnEntrar.setOnClickListener {

            val email = edtEmail.text.toString().trim()
            val senha = edtSenha.text.toString()

            if (email.isBlank() || senha.isBlank()) {

                Toast.makeText(
                    this,
                    "Preencha o e-mail e a senha.",
                    Toast.LENGTH_SHORT
                ).show()

            } else {

                val usuarioEncontrado = DadosSimulados.usuarios.firstOrNull {
                    it.email.equals(email, ignoreCase = true) &&
                            it.senha == senha &&
                            it.perfil == "Motorista"
                }

                if (usuarioEncontrado != null) {

                    val intent = Intent(this, PainelMotorista::class.java)

                    intent.putExtra(
                        PainelMotorista.EXTRA_NOME_MOTORISTA,
                        usuarioEncontrado.nome
                    )

                    startActivity(intent)
                    finish()

                } else {

                    Toast.makeText(
                        this,
                        "E-mail ou senha inválidos.",
                        Toast.LENGTH_SHORT
                    ).show()
                }
            }
        }
    }
}