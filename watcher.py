import os,time
from win10toast import ToastNotifier

def watcher():
    mydate = datetime.datetime.now()
    if os.path.exists("watchlist.txt") == True:
        watchlist = open("watchlist.txt", "r")
    for line in watchlist:
        branchFolder = os.listdir("Z://{0}//{1}//{2}//PC//".format(mydate.year,mydate.strftime("%B"),line))
        with open("{}".format(line), "w+") as branchBefore:
            for file in branchFolder:
                branchBefore.write(file)
    time.sleep(300)
    for line in watchlist:
        branchFolder = os.listdir("Z://{0}//{1}//{2}//PC//".format(mydate.year,mydate.strftime("%B"),line))
        with open("{}".format(line), "r") as branchBefore:
            for newFile in branchFolder:
                for oldFile in branchBefore:
                    alreadyExisted == False
                    if newFile == oldFile:
                        alreadyExisted = True
                if alreadyExisted == False:
                    notifier(line,newFile)
    return()

def notifier(branch, file):
    toaster.show_toast("Silhouette New Build detecter","{0} is now avaliable in {1}".format(branch,file), icon_path="silhouette_logo.ico", threaded=True)
    return()