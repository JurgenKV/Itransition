import hashlib
import os

pt = os.getcwd()
folderName = "\\task2"
mailStr = "yura.kireev.vt@gmail.com"

dirList = os.listdir(pt + folderName)
finalStr = ""
hexList = []

for i in range(len(dirList)):
    p = pt + folderName + "\\" + dirList[i]
    with open(p, 'rb') as u:
        y = u.read()
    w = hashlib.sha3_256(y)
    hexList.append(w.hexdigest())

hexList = sorted(hexList)

for i in range(len(hexList)):
    finalStr += hexList[i]

finalStr += mailStr
finalStr = finalStr.encode()
print(hashlib.sha3_256(finalStr).hexdigest())