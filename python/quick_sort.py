import random
import time

class Quick(object):
    def particao(self, array, start, end):
        pivo = array[end - 1]
        inicio = start
        fim = start
        for i in range(start, end):
            if array[i] > pivo:
                fim += 1
            else:
                fim += 1       
                inicio += 1
                array[i], array[inicio-1] = array[inicio-1], array[i]
        return inicio - 1
        
    def quickSort(self, array, start, end):
        if start < end:
            pp = self.rand_particao(array, start, end)
            self.quickSort(array, start, pp)
            self.quickSort(array, pp+1, end)
        return array
        
    def rand_particao(self, array, start, end):
        rand = random.randrange(start, end)
        array[rand], array[end-1] = array[end-1], array[rand]
        return self.particao(array, start, end)

entrada = input("Arquivo a ser executado: \n (1 - vetordesordenado1k, 2 - vetordesordenado10k," + 
            " 3 - vetordesordenado100k \n  4 - vetorordenado1k, 5 - vetorordenado10k," + 
            " 6 - vetorordenado100k \n  7 - vetorordenadodesc1k, 8 - vetorordenadodesc10k, 9 - vetorordenadodesc100k) ")

dicionario = {'1' : 'vetordesordenado1k', '2' : 'vetordesordenado10k', '3' : 'vetordesordenado100k',
                '4' : 'vetorordenado1k', '5' : 'vetorordenado10k', '6' : 'vetorordenado100k',
                '7' : 'vetorordenadodesc1k', '8' : 'vetorordenadodesc10k', '9' : 'vetorordenadodesc100k'}

nome = dicionario[entrada]
print(nome)
arquivo = open(str(nome), 'r')
array = arquivo.readlines()

t0 = time.time()

quick = Quick()
print (quick.quickSort(array,0,len(array)))

tf = time.time()

dt = (tf - t0)*1000000

print(f"Quick Sort com {len(array)} entradas do arquivo {nome} levou {dt} microsegundos!")

