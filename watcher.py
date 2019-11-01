import os,time, datetime
from win10toast import ToastNotifier
from threading import Thread

def watcherThreadFunct(branches):
    watcherThread = Thread(target = watcher(branches))
    watcherThread.start()
    watcherThread.join()
    return()

def watcher(branches):
    for item in branches:
        item = item.replace("\n", "")
    mydate = datetime.datetime.now()
    if os.path.exists("watchlist.txt") == True:
        watchlist = open("watchlist.txt", "r")
    for line in watchlist:
        strippedLine = line.rstrip("\n")
        branchFolder = branches
        with open("{}.txt".format(strippedLine), "w+") as branchBefore:
            for file in branchFolder:
                branchBefore.write(file+"\n")
    print("Starting Sleep")
    time.sleep(300)
    for line in watchlist:
        strippedLine = line.rstrip("\n")
        branchFolder = branches
        with open("{}.txt".format(strippedLine), "r") as branchBefore:
            for newFile in branchFolder:
                for oldFile in branchBefore:
                    alreadyExisted == False
                    if newFile == oldFile:
                        alreadyExisted = True
                if alreadyExisted == False:
                    notifier(strippedLine,newFile)
    return()

def notifier(branch, file):
    toaster.show_toast("Silhouette New Build detecter","{0} is now avaliable in {1}".format(branch,file), icon_path="silhouette_logo.ico", threaded=True)
    return()