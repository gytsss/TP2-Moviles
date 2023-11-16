package com.godoy.mylibrary;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileWriter;
import java.io.IOException;
import java.lang.reflect.Array;
import java.util.ArrayList;

public class GodoyLogger {

    private File logFile;
    static final String LOGTAG = "GodLOG";
    public static Activity mainActivity;

    public interface AlertViewCallBack {
        public void onButtonTapped(int id);
    }

    static GodoyLogger _instance = null;

    public static GodoyLogger getInstance() {
        if (_instance == null)
            _instance = new GodoyLogger();
        return _instance;
    }

    public String getLogtag() {
        return LOGTAG;
    }

    public void showAlertView(String[] strings, final AlertViewCallBack callBack) {
        if (strings.length < 3) {
            Log.i(LOGTAG, "Error - expected at least 3 strings, got " + strings.length);
            return;
        }

        DialogInterface.OnClickListener myClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.dismiss();
                Log.i(LOGTAG, "Tapped: " + which);
                callBack.onButtonTapped(which);
            }
        };

        AlertDialog alertDialog = new AlertDialog.Builder(mainActivity)
                .setTitle(strings[0])
                .setMessage(strings[1])
                .setCancelable(false)
                .create();
        alertDialog.setButton(alertDialog.BUTTON_NEUTRAL, strings[2], myClickListener);
        if (strings.length > 3) {
            alertDialog.setButton(alertDialog.BUTTON_NEGATIVE, strings[3], myClickListener);
            clearUnityLogs();
            Log.v(LOGTAG, "Press yes");
        }
        if (strings.length > 4) {
            alertDialog.setButton(alertDialog.BUTTON_POSITIVE, strings[4], myClickListener);
            Log.v(LOGTAG, "Press cancel");
        }
        alertDialog.show();

    }

    public GodoyLogger() {
        logFile = new File(mainActivity.getFilesDir(), "unity_logs.txt");


        if (!logFile.exists()) {
            try {
                logFile.createNewFile();
                Log.v(LOGTAG, "File created");
            } catch (IOException e) {
                Log.e(LOGTAG, "Error creating logs file", e);
            }
        }
    }

    public void logFromUnity(String log) {

        try {
            logFile = new File(mainActivity.getFilesDir(), "unity_logs.txt");
            FileWriter fileWriter = new FileWriter(logFile, true);
            fileWriter.append(log + " ");
            Log.d(LOGTAG, "Writing: " + log);
            fileWriter.close();
            Log.d(LOGTAG, "Close file after writing");
        } catch (IOException e) {
            Log.e(LOGTAG, "Error writing logs file", e);
        }
    }

    public String ReadFile()
    {
        byte[] content = new byte[(int)logFile.length()];
        if(logFile.exists())
        {
            try
            {
                FileInputStream fis = new FileInputStream(logFile);
                fis.read(content);
                Log.v(LOGTAG, "Correctly read");
                return new String(content);
            }
            catch (IOException e)
            {
                Log.e(LOGTAG, "Error reading logs file", e);
                return "Error reading logs file";
            }
        }
        else {
            Log.e(LOGTAG, "Error 404 file");
            return "File 404";
        }
    }

    public void clearUnityLogs()
    {
        if(logFile.exists())
        {
            logFile.delete();
            Log.v(LOGTAG, "File deleted");
            try
            {
                logFile.createNewFile();
                Log.v(LOGTAG, "File created again");
            }
            catch (IOException e)
            {
                Log.e(LOGTAG, "Error deleting logs file", e);
            }
        }
    }

    public void debugLog(String log)
    {
        Log.v(LOGTAG, log);
    }

}
