from numpy import *
import matplotlib.pyplot as pl
class Hopfield:
    """Сеть Хопфилда"""
    def __init__(self,input):
        self.input=input
        self.Weight=self.__GetWeigtMatrix(input)    

    def __GetWeigtMatrix(cls,train):
        '''Получение матрицы весов'''
        W=zeros((len(train[0]),len(train[0])))
        for tr in train:
            V2=matrix(tr)
            V1=transpose(V2)
            W+=dot(V1,V2)
        W-=diag(diag(W))
        return W   

    def Compute(self,check):
        '''Получить класс'''
        y=transpose(matrix(check))
        y1=sign(dot(self.Weight,y))
        y2=sign(dot(self.Weight,y1))
        while not(y1==y2).all():
            y1=y2
            y2=sign(dot(self.Weight,y1))
        return y2

class Associative:
   def __init__(self,input):
       self.input=input
       self.Weight=self.GetWeight(input)

   def GetWeight(self,input):
       l=list(input.values())[0]
       k=list(input.keys())[0]
       W=zeros((len(l),len(k)))
       for item in input:
           m=matrix(input[item])
           W+=dot(transpose(m),matrix(item))
       return W

   def Compute(self,check):
       x1=sign(dot(check,self.Weight))
       y1=sign(dot(x1,transpose(self.Weight)))
       x2=sign(dot(y1,self.Weight))
       y2=sign(dot(x2,transpose(self.Weight)))
       while not (x1==x2).all() and not (y1==y2).all():
           x1,y1=x2,y2
           x2=sign(dot(y1,self.Weight))
           y2=sign(dot(x2,transpose(self.Weight)))
       return (x2,y2)


def MultiplicativeNoise(dict):
    noize=tuple(i if i==1 else -1 for i in random.randint(0,2,len(dict)))
    return array(noize)*array(dict)


def AdditiveNoize(dict):
    noize=tuple(i if i==1 else -1 for i in random.randint(0,2,len(dict)))
    return array([-1 if i==-2 else 1 for i in array(noize)+array(dict)])

def Generate(train,NoizeFunct,count):
    source=[]
    check=[]
    keys=list(train.keys())
    for i in range(count):
        key=keys[random.randint(0,len(train)-1 if len(train)>1 else len(train))]
        source.append(key)
        check.append(NoizeFunct(train[key]))
    return (source,check)
