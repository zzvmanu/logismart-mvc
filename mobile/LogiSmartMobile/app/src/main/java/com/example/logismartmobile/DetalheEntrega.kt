package com.example.logismartmobile

import android.os.Bundle
import android.graphics.Color
import android.widget.Button
import android.widget.TextView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity

class DetalheEntrega : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detalhe_entrega)

        // Recupera o ID da entrega selecionada
        val entregaId = intent.getIntExtra(
            EXTRA_ENTREGA_ID,
            -1
        )

        // Procura a entrega nos dados simulados
        val entrega = DadosSimulados.entregas.firstOrNull {
            it.id == entregaId
        }

        // Verifica se a entrega foi encontrada
        if (entrega == null) {
            Toast.makeText(
                this,
                "Entrega não encontrada.",
                Toast.LENGTH_SHORT
            ).show()

            finish()
            return
        }

        // Localiza os componentes da tela
        val tvPedidoId =
            findViewById<TextView>(R.id.tvPedidoId)

        val tvCliente =
            findViewById<TextView>(R.id.tvCliente)

        val tvEndereco =
            findViewById<TextView>(R.id.tvEndereco)

        val tvStatus =
            findViewById<TextView>(R.id.tvStatus)

        val btnAtualizarStatus =
            findViewById<Button>(R.id.btnAtualizarStatus)

        val btnVoltarEntregas =
            findViewById<Button>(R.id.btnVoltarEntregas)

        // Voltar para a lista de entregas
        btnVoltarEntregas.setOnClickListener {
            finish()
        }

        // Atualiza as informações exibidas na tela
        fun atualizarTela() {

            tvPedidoId.text = "Pedido #${entrega.id}"
            tvCliente.text = entrega.cliente
            tvEndereco.text = entrega.endereco
            tvStatus.text = entrega.status

            // Define a cor conforme o status
            val corStatus = when (entrega.status) {
                "Pendente" ->
                    Color.parseColor("#FBBF24")

                "Em andamento" ->
                    Color.parseColor("#9CCBFF")

                "Concluído" ->
                    Color.parseColor("#63D6A5")

                else -> Color.WHITE
            }

            tvStatus.setTextColor(corStatus)

            // Define o texto do botão
            btnAtualizarStatus.text = when (entrega.status) {
                "Pendente" -> "Iniciar entrega"
                "Em andamento" -> "Concluir entrega"
                "Concluído" -> "Entrega concluída"
                else -> "Atualizar status"
            }

            // Impede novas alterações após a conclusão
            btnAtualizarStatus.isEnabled =
                entrega.status != "Concluído"
        }

        // Exibe os dados iniciais
        atualizarTela()

        // Atualiza o status da entrega
        btnAtualizarStatus.setOnClickListener {

            when (entrega.status) {

                "Pendente" -> {
                    entrega.status = "Em andamento"
                }

                "Em andamento" -> {
                    entrega.status = "Concluído"
                }

                "Concluído" -> {
                    return@setOnClickListener
                }
            }

            // Atualiza as informações na tela
            atualizarTela()

            Toast.makeText(
                this,
                "Status atualizado: ${entrega.status}",
                Toast.LENGTH_SHORT
            ).show()
        }
    }

    companion object {
        const val EXTRA_ENTREGA_ID = "entrega_id"
    }
}