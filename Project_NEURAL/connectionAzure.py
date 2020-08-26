import asyncio
import json
import sys
import time
sys.path.append('/usr/local/lib/python3.7/dist-packages')
from azure.iot.device.aio import IoTHubDeviceClient


conn_str = "HostName=DigitalParkingPi.azure-devices.net;DeviceId=Pi4Camera;SharedAccessKey=tdd+yGp/Nl5UsaZf1yztvzZ6WV8k8Jmdeqk1nIayHEI="
conOK = 0

with open("compare.txt", "r") as compare :
	compare_contents = compare.read()

with open("forcom.txt", "r+") as forcom:

	forcom_contents = forcom.read()

	if (compare_contents != forcom_contents):
		forcom.seek(0)
		forcom.write(compare_contents)
		conOK = 1

	if (compare_contents == forcom_contents):
		print("Sao Iguais!")
		conOK = 0
async def opencon():
	with open("forcom.txt","r") as REALforcom:
		REALforcom.seek(6)
		A_1 = REALforcom.read(1)
		REALforcom.seek(14)
		A_2 = REALforcom.read(1)
		REALforcom.seek(22)
		A_3 = REALforcom.read(1)
		REALforcom.seek(30)
		A_4 = REALforcom.read(1)
		REALforcom.seek(39)
		FORA = REALforcom.read(1)
		print(A_1)

		device_client = IoTHubDeviceClient.create_from_connection_string(conn_str)
		await device_client.connect()
		data = {
			"A-1":A_1,
			"A-2":A_2,
			"A-3":A_3,
			"A-4":A_4,
			"FORA":FORA }
		json_body = json.dumps(data)
		print("Sending Message:",json_body)
		await device_client.send_message(json_body)
		time.sleep(2)
		await device_client.disconnect()

if(conOK==1):
	asyncio.run(opencon())
