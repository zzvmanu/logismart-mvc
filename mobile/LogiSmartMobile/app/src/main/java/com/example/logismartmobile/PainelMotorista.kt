package com.example.logismartmobile

import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import android.content.Intent

class PainelMotorista : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_painel_motorista)

        // Recupera o nome enviado pelo login
        val nomeMotorista = intent.getStringExtra(EXTRA_NOME_MOTORISTA)
            ?: "Motorista"

        // Localiza os componentes do painel
        val tvNomeMotorista =
            findViewById<TextView>(R.id.tvNomeMotorista)

        val tvTotalEntregas =
            findViewById<TextView>(R.id.tvTotalEntregas)

        val tvConcluidas =
            findViewById<TextView>(R.id.tvConcluidas)

        val btnVerEntregas =
            findViewById<Button>(R.id.btnVerEntregas)

        // Apresenta o nome do motorista
        tvNomeMotorista.text = "Olá, $nomeMotorista!"

        // Calcula o total de entregas
        val total = DadosSimulados.entregas.size

        // Calcula as entregas concluídas
        val concluidas = DadosSimulados.entregas.count {
            it.status.equals("Concluído", ignoreCase = true)
        }

        // Atualiza os números na tela
        tvTotalEntregas.text = "%02d".format(total)
        tvConcluidas.text = "%02d".format(concluidas)

        // Ação do botão de entregas
        btnVerEntregas.setOnClickListener {
            val intent = Intent(this, Entregas::class.java)
            startActivity(intent)
        }
    }

    companion object {
        const val EXTRA_NOME_MOTORISTA = "nome_motorista"
    }
}