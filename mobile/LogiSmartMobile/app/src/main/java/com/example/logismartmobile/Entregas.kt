package com.example.logismartmobile

import android.content.Intent
import android.graphics.Color
import android.graphics.Typeface
import android.graphics.drawable.GradientDrawable
import android.os.Bundle
import android.widget.Button
import android.widget.LinearLayout
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class Entregas : AppCompatActivity() {

    // Container que recebe os cartões
    private lateinit var container: LinearLayout

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_entregas)

        container = findViewById(R.id.containerEntregas)

        // Botão para voltar ao painel
        val btnVoltarPainel =
            findViewById<Button>(R.id.btnVoltarPainel)

        btnVoltarPainel.setOnClickListener {
            finish()
        }
    }

    // Atualiza a lista sempre que a tela voltar a aparecer
    override fun onResume() {
        super.onResume()
        carregarEntregas()
    }

    // Carrega as entregas simuladas
    private fun carregarEntregas() {

        // Remove os cartões antigos
        container.removeAllViews()

        val listaEntregas = DadosSimulados.entregas

        if (listaEntregas.isEmpty()) {

            val mensagem = criarTexto(
                "Nenhuma entrega encontrada.",
                16f,
                Color.WHITE
            )

            container.addView(mensagem)

        } else {

            listaEntregas.forEach { entrega ->
                val cartao = criarCartao(entrega)
                container.addView(cartao)
            }
        }
    }

    // Cria o cartão de cada entrega
    private fun criarCartao(entrega: Entrega): LinearLayout {

        val cartao = LinearLayout(this).apply {
            orientation = LinearLayout.VERTICAL

            setPadding(
                dp(16),
                dp(16),
                dp(16),
                dp(16)
            )

            background = GradientDrawable().apply {
                setColor(Color.parseColor("#1C2B47"))
                cornerRadius = dp(12).toFloat()
            }

            layoutParams = LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.MATCH_PARENT,
                LinearLayout.LayoutParams.WRAP_CONTENT
            ).apply {
                bottomMargin = dp(16)
            }
        }

        // Número do pedido
        cartao.addView(
            criarTexto(
                "Pedido #${entrega.id}",
                18f,
                Color.WHITE,
                true
            )
        )

        // Cliente
        cartao.addView(
            criarTexto(
                "Cliente: ${entrega.cliente}",
                15f,
                Color.WHITE
            )
        )

        // Endereço
        cartao.addView(
            criarTexto(
                "Endereço: ${entrega.endereco}",
                14f,
                Color.LTGRAY
            )
        )

        // Cor do status
        val corStatus = when (entrega.status) {
            "Pendente" -> Color.parseColor("#FBBF24")
            "Em andamento" -> Color.parseColor("#9CCBFF")
            "Concluído" -> Color.parseColor("#63D6A5")
            else -> Color.WHITE
        }

        // Status da entrega
        cartao.addView(
            criarTexto(
                "Status: ${entrega.status}",
                14f,
                corStatus,
                true
            )
        )

        // Permite clicar no cartão
        cartao.isClickable = true
        cartao.isFocusable = true

        cartao.setOnClickListener {

            val intent = Intent(
                this,
                DetalheEntrega::class.java
            )

            intent.putExtra(
                DetalheEntrega.EXTRA_ENTREGA_ID,
                entrega.id
            )

            startActivity(intent)
        }

        return cartao
    }

    // Cria os textos dos cartões
    private fun criarTexto(
        texto: String,
        tamanho: Float,
        cor: Int,
        negrito: Boolean = false
    ): TextView {

        return TextView(this).apply {
            text = texto
            textSize = tamanho
            setTextColor(cor)

            if (negrito) {
                setTypeface(null, Typeface.BOLD)
            }

            layoutParams = LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.MATCH_PARENT,
                LinearLayout.LayoutParams.WRAP_CONTENT
            ).apply {
                topMargin = dp(6)
            }
        }
    }

    // Converte dp para pixels
    private fun dp(valor: Int): Int {
        return (valor * resources.displayMetrics.density).toInt()
    }
}