import time

def heap(array, n, i):
    maior = i
    esquerda = 2 * i + 1
    direita = 2 * i + 2

    if esquerda < n and array[i] < array[esquerda]:
        maior = esquerda

    if direita < n and array[maior] < array[direita]:
        maior = direita

    if maior != i:
        array[i], array[maior] = array[maior], array[i]
        heap(array, n, maior)


def heap_sort(array):
    n = len(array)

    for i in range(n//2, -1, -1):
        heap(array, n, i)

    for i in range(n-1, 0, -1):
        array[i], array[0] = array[0], array[i]

        heap(array, i, 0)


entrada = input("Arquivo a ser executado: \n (1 - vetordesordenado1k, 2 - vetordesordenado10k," + 
            " 3 - vetordesordenado100k \n  4 - vetorordenado1k, 5 - vetorordenado10k," + 
            " 6 - vetorordenado100k \n  7 - vetorordenadodesc1k, 8 - vetorordenadodesc10k, 9 - vetorordenadodesc100k) ")

dicionario = {'1' : 'vetordesordenado1k', '2' : 'vetordesordenado10k', '3' : 'vetordesordenado100k',
                '4' : 'vetorordenado1k', '5' : 'vetorordenado10k', '6' : 'vetorordenado100k',
                '7' : 'vetorordenadodesc1k', '8' : 'vetorordenadodesc10k', '9' : 'vetorordenadodesc100k'}

nome = dicionario[entrada]
arquivo = open(str(nome), 'r')
array = arquivo.readlines()

t0 = time.time()

heap_sort(array)

tf = time.time()

dt = (tf - t0)*1000000

print(f"HeapSort com {len(array)} entradas do arquivo {nome} levou {dt} microsegundos!")
