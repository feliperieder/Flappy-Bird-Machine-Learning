# Flappy Bird AI com Unity ML-Agents

Projeto desenvolvido utilizando Unity e ML-Agents para treinar uma Inteligência Artificial capaz de aprender a jogar Flappy Bird através de Aprendizado por Reforço (Reinforcement Learning), utilizando o algoritmo PPO (Proximal Policy Optimization).

---

## Objetivo

Investigar o processo de aprendizado de um agente autônomo em um ambiente dinâmico, analisando sua evolução ao longo do treinamento e sua capacidade de maximizar recompensas através de interação com o ambiente.

---

## Tecnologias Utilizadas

- Unity
- C#
- Unity ML-Agents
- Python
- PyTorch
- TensorBoard
- Anaconda

---

## Funcionamento do Agente

O agente controla o pássaro e recebe observações contínuas do ambiente, incluindo:

- Posição vertical do pássaro  
- Velocidade vertical  
- Distância até o próximo cano  
- Diferença de altura entre o pássaro e a abertura do cano  

Com base nessas informações, a rede neural decide entre:

- Não executar ação  
- Realizar um salto  

---

## Sistema de Recompensas

O aprendizado é guiado por recompensas e penalidades:

### Recompensas

- +10 ao atravessar um cano (checkpoint)

### Penalidades

- -5 ao colidir com canos, chão ou teto  
- +0.01 por ação de voo (utilizada como incentivo comportamental)

---

## Treinamento (PPO - ML-Agents)

O agente foi treinado utilizando o algoritmo PPO fornecido pelo Unity ML-Agents.

## Configuração do Treinamento

O arquivo de configuração do ML-Agents (`FlappyML.yaml`) possui a seguinte estrutura:
```yaml
behaviors:
  FlappyBird:
    trainer_type: ppo

    hyperparameters:
      batch_size: 256
      buffer_size: 4096
      learning_rate: 5.0e-5
      beta: 5.0e-4
      epsilon: 0.2
      lambd: 0.95
      num_epoch: 3
      learning_rate_schedule: linear

    network_settings:
      normalize: false
      hidden_units: 128
      num_layers: 2

    reward_signals:
      extrinsic:
        gamma: 0.995
        strength: 1.0

    max_steps: 2000000
    time_horizon: 64
    summary_freq: 10000

    checkpoint_interval: 50000
    keep_checkpoints: 10
```


### Configuração do Ambiente Python (Anaconda)

```bash
conda create -n mlagents python=3.10
conda activate mlagents
pip install mlagents


