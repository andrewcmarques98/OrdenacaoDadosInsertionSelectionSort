import time

def merge_sort(array):
    if len(array) > 1:
        meio = len(array)//2

        lista_esquerda = array[:meio]
        lista_direita = array[meio:]

        merge_sort(lista_esquerda)
        merge_sort(lista_direita)

        x = 0
        y = 0
        z = 0

        while x < len(lista_esquerda) and y < len(lista_direita):

            if lista_esquerda[x] < lista_direita[y]:
                array[z] = lista_esquerda[x]
                x += 1
            else:
                array[z] = lista_direita[y]
                y += 1
            z += 1

        while x < len(lista_esquerda):

            array[z] = lista_esquerda[x]
            x += 1
            z += 1

        while y < len(lista_direita):
            array[z] = lista_direita[y]
            y += 1
            z += 1


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

merge_sort(array)

tf = time.time()

dt = (tf - t0)*1000000

print(f"Merge Sort com {len(array)} entradas do arquivo {nome} levou {dt} microsegundos!")