#! Ассоциативная сеть
from Classes import *
import numpy as np
import matplotlib.pyplot as pl
import random

e=((-1,1),(1,-1),(1,1))
train={
   (-1,-1,-1,1):
   (
   -1,-1,-1,-1,-1,-1,-1,
   -1,-1,-1,1,-1,-1,-1,
   -1,-1,1,1,-1,-1,-1,
   -1,-1,-1,1,-1,-1,-1,
   -1,-1,-1,1,-1,-1,-1,
   -1,-1,-1,1,-1,-1,-1,
   -1,-1,-1,1,-1,-1,-1,
   -1,1,1,1,1,1,-1,
   -1,-1,-1,-1,-1,-1,-1
   ),
    (-1,-1,1,-1):
   (
       -1,-1,-1,-1,-1,-1,-1,
       -1,1,1,1,1,1,-1,
       -1,-1,-1,-1,-1,1,-1,
       -1,-1,-1,-1,-1,1,-1,
       -1,1,1,1,1,1,-1,
       -1,1,-1,-1,-1,-1,-1,
       -1,1,-1,-1,-1,-1,-1,
       -1,1,1,1,1,1,-1,
       -1,-1,-1,-1,-1,-1,-1,
   ),
   (-1,-1,1,1):
   (
       -1,-1,-1,-1,-1,-1,-1,
       -1,1,1,1,1,1,-1,
       -1,-1,-1,-1,-1,1,-1,
       -1,-1,-1,-1,-1,1,-1,
       -1,-1,-1,1,1,1,-1,
       -1,-1,-1,-1,-1,1,-1,
       -1,-1,-1,-1,-1,1,-1,
       -1,1,1,1,1,1,-1,
       -1,-1,-1,-1,-1,-1,-1
   ),
   (-1,1,-1,-1):
   (
      -1,1,-1,-1,-1,1,-1,
      -1,1,-1,-1,-1,1,-1,
      -1,1,-1,-1,-1,1,-1,
      -1,1,-1,-1,-1,1,-1,
      -1,1,1,1,1,1,-1,
      -1,-1,-1,-1,-1,1,-1,
      -1,-1,-1,-1,-1,1,-1,
      -1,-1,-1,-1,-1,1,-1,
      -1,-1,-1,-1,-1,1,-1
   )
   }
check=((
   (-1,1,-1,-1,-1,-1,-1),
   (-1,-1,-1,1,-1,-1,-1),
   (-1,-1,1,1,-1,1,-1),
   (-1,-1,1,1,-1,-1,-1),
   (-1,1,-1,1,-1,-1,-1),
   (-1,-1,-1,1,-1,1,-1),
   (-1,-1,-1,1,-1,-1,-1),
   (-1,1,1,1,1,1,-1),
   (-1,-1,-1,1,-1,1,-1)
   ),
   (
       (-1,-1,1,-1,-1,1,-1),
       (-1,1,1,1,1,1,-1),
       (-1,-1,1,-1,-1,1,-1),
       (-1,1,-1,-1,-1,1,-1),
       (-1,1,1,1,1,1,-1),
       (1,1,-1,1,-1,-1,-1),
       (-1,1,-1,-1,-1,-1,-1),
       (-1,1,1,1,1,1,-1),
       (-1,-1,-1,-1,1,-1,-1),
   ),
   (
       (-1,-1,-1,-1,-1,-1,-1),
       (-1,1,1,1,1,-1,-1),
       (-1,-1,-1,-1,-1,1,-1),
       (1,-1,-1,-1,-1,1,-1),
       (-1,-1,-1,1,-1,1,-1),
       (-1,-1,-1,-1,-1,1,-1),
       (1,-1,-1,-1,-1,1,-1),
       (-1,1,1,-1,1,1,-1),
       (-1,-1,-1,-1,-1,-1,-1)
   ),
    (
       (-1,-1,-1,-1,-1,-1,-1),
       (-1,-1,-1,1,-1,1,-1),
       (-1,-1,1,1,-1,-1,-1),
       (-1,-1,-1,-1,-1,-1,-1),
       (-1,1,-1,1,-1,-1,-1),
       (-1,-1,-1,1,-1,-1,-1),
       (-1,1,-1,-1,-1,-1,-1),
       (-1,1,1,1,1,1,-1),
       (-1,1,-1,-1,-1,-1,-1)
       ),
   (
       (-1,-1,1,-1,-1,-1,-1),
       (-1,1,1,1,1,1,-1),
       (1,-1,1,-1,-1,1,-1),
       (-1,-1,-1,-1,-1,1,-1),
       (1,1,-1,1,1,-1,-1),
       (-1,1,-1,-1,1,-1,-1),
       (-1,1,-1,1,-1,-1,-1),
       (-1,1,1,-1,1,1,-1),
       (-1,-1,-1,-1,-1,-1,-1),
   ),
   (
       (-1,-1,-1,-1,-1,-1,-1),
       (-1,1,1,-1,1,1,-1),
       (-1,-1,1,-1,-1,1,-1),
       (1,-1,-1,-1,-1,-1,-1),
       (-1,-1,-1,-1,1,1,-1),
       (-1,-1,1,-1,-1,1,-1),
       (-1,-1,-1,1,-1,1,1),
       (-1,1,1,-1,1,1,-1),
       (-1,1,-1,-1,-1,-1,-1)
   )
   )
test={
     (-1,-1,1):
     (
       -1,1,-1,
       1,1,-1,
       -1,1,-1,
       -1,1,-1,
       1,1,1
         ),
     (-1,1,-1):
     (
       1,1,1,
       -1,-1,1,
       1,1,1,
       1,-1,-1,
       1,1,1,
         ),   
     (-1,1,1):
     (
       1,1,1,
       -1,-1,1,
       1,1,1,
       -1,-1,1,
       1,1,1,
         )
    }

testcheck=(
     (
       (-1,1,-1),
       (1,1,-1),
       (-1,-1,-1),
       (-1,1,-1),
       (1,1,1),
         ),
     (
       (1,1,1),
       (-1,-1,1),
       (1,-1,1),
       (1,-1,-1),
       (1,-1,1),
         ),   

     (
       (1,1,-1),
       (1,-1,1),
       (1,1,1),
       (-1,-1,1),
       (1,1,1),
         )
    )

def MultiplicativeNoise(dict):
#   list=dict.keys()
#    check=[]
 #   for key in list:
    noize=tuple(i if i==1 else -1 for i in np.random.randint(0,2,len(dict)))
    return np.array(noize)*np.array(dict)
#    return check

def AdditiveNoize(dict):
    noize=tuple(i if i==1 else -1 for i in np.random.randint(0,2,len(dict)))
    return np.array([-1 if i==-2 else 1 for i in np.array(noize)+np.array(dict)])

def Generate(train,NoizeFunct,count):
    source=[]
    check=[]
    keys=list(train.keys())
    for i in range(count):
        key=keys[random.randint(0,len(train)-1)]
        source.append(key)
        check.append(NoizeFunct(train[key]))
    return (source,check)

def main(): 
    ass=Associative(test)
    fig,axs=pl.subplots(3,3) 
    source,check=Generate(test,AdditiveNoize,3)
    for i in range(3):
        axs[0,i].imshow(np.array(test[source[i]]).reshape(5,3))
        axs[1,i].imshow(check[i].reshape(5,3))
        res,img=ass.Compute(check[i])
        axs[2,i].imshow(img.reshape(5,3))

    ass1=Associative(train)
    fig1,axes=pl.subplots(3,6) 
    source,check=Generate(train,AdditiveNoize,6)
    for i in range(6):
        axes[0,i].imshow(np.array(train[source[i]]).reshape(9,7))
        axes[1,i].imshow(check[i].reshape(9,7))
        res,img=ass1.Compute(check[i])
        axes[2,i].imshow(img.reshape(9,7))

    sourceA,checkA=Generate(train,AdditiveNoize,1000)
    sourceM,checkM=Generate(train,MultiplicativeNoise,1000)
    clear=list(train.items())*333+list(random.choice(list(train.items())))
    random.shuffle(clear)

    rA=0
    rM=0
    r=0
    resdict={}
    for i in range(1000):
        resA,imgA=ass1.Compute(checkA[i])
        resM,imgM=ass1.Compute(checkM[i])
        resC,imgR=ass1.Compute(np.array(clear[i][1]))
        if (sourceA[i]==resA).all():
            rA+=1
        if (sourceM[i]==resM).all():
            rM+=1
        if (clear[i][0]==resC).all():
            r+=1
            try:
                resdict[clear[i][0]]+=1
            except KeyError:
                resdict[clear[i][0]]=1            
    print("Additive:{0:.2%} Multiplicative:{1:.2%} WithoutNoize:{2:.2%}\n {3}".format(rA/1000,rM/1000,r/1000,resdict))
    pl.show()




if __name__=="__main__":
    main()