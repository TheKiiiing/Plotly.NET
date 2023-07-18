﻿module CoreTests.HTMLCodegen.Chart3D

open Expecto
open Plotly.NET
open Plotly.NET.LayoutObjects
open Plotly.NET.TraceObjects
open Plotly.NET.GenericChart

open TestUtils.HtmlCodegen
open Chart3DTestCharts

module Scatter3D =
    [<Tests>]
    let ``Scatter3D chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Scatter3D" [
                testCase "3D Scatter charts data" ( fun () ->
                    """var data = [{"type":"scatter3d","mode":"markers","x":[19,26,55],"y":[19,26,55],"z":[19,26,55],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains Scatter3D.``Simple scatter3d chart with axis titles``
                );
                testCase "3D Scatter charts layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}},"xaxis":{"title":{"text":"my x-axis"}},"yaxis":{"title":{"text":"my y-axis"}},"zaxis":{"title":{"text":"my z-axis"}}},"width":800,"height":800};"""
                    |> chartGeneratedContains Scatter3D.``Simple scatter3d chart with axis titles``
                );
            ]
        ]
        
module Point3D =
    [<Tests>]
    let ``Point3D chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Point3D" [
                testCase "3D Point charts data" ( fun () ->
                    """var data = [{"type":"scatter3d","mode":"markers","x":[19,26,55],"y":[19,26,55],"z":[19,26,55],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains Point3D.``Simple Point3D chart with axis titles``
                );
                testCase "3D Point charts layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}},"xaxis":{"title":{"text":"my x-axis"}},"yaxis":{"title":{"text":"my y-axis"}},"zaxis":{"title":{"text":"my z-axis"}}},"width":800,"height":800};"""
                    |> chartGeneratedContains Point3D.``Simple Point3D chart with axis titles``
                );
            ]
        ]
        
module Line3D =
    [<Tests>]
    let ``Line3D chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Line3D" [
                testCase "Line data" ( fun () ->
                    """var data = [{"type":"scatter3d","mode":"lines+markers","x":[10.0,8.765,5.376,0.699,-4.079,-7.762,-9.458,-8.797,-6.02,-1.898,2.489,6.042,7.925,7.774,5.766,2.536,-1.014,-3.973,-5.664,-5.8,-4.534,-2.366,0.02,1.974,3.058,3.146,2.427,1.303,0.232,-0.428,-0.537],"y":[0.0,4.788,8.373,9.863,8.912,5.799,1.348,-3.295,-6.971,-8.802,-8.415,-6.015,-2.306,1.713,5.025,6.863,6.893,5.27,2.562,-0.437,-2.939,-4.377,-4.536,-3.576,-1.944,-0.209,1.124,1.76,1.684,1.127,0.46],"z":[0.0,0.5,1.0,1.5,2.0,2.5,3.0,3.5,4.0,4.5,5.0,5.5,6.0,6.5,7.0,7.5,8.0,8.5,9.0,9.5,10.0,10.5,11.0,11.5,12.0,12.5,13.0,13.5,14.0,14.5,15.0],"marker":{},"line":{}}];"""
                    |> chartGeneratedContains Line3D.``Upwards spiral line 3D chart with markers``
                );
                testCase "Line layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}},"xaxis":{"title":{"text":"x-axis"}},"yaxis":{"title":{"text":"y-axis"}},"zaxis":{"title":{"text":"z-axis"}}},"width":800,"height":800};"""
                    |> chartGeneratedContains Line3D.``Upwards spiral line 3D chart with markers``
                );
            ]
        ]
        
module Bubble3D =
    [<Tests>]
    let ``Bubble3D chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Bubble3D" [
                testCase "Bubble data" ( fun () ->
                    """var data = [{"type":"scatter3d","mode":"markers+text","x":[1,6,7],"y":[3,5,9],"z":[2,4,8],"text":["A","B","C"],"textposition":"top left","marker":{"size":[20,40,30]}}];"""
                    |> chartGeneratedContains Bubble3D.``Simple Bubble3D chart with axis titles``
                );
                testCase "Bubble layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}},"xaxis":{"title":{"text":"x-axis"}},"yaxis":{"title":{"text":"y-axis"}},"zaxis":{"title":{"text":"z-axis"}}}};"""
                    |> chartGeneratedContains Bubble3D.``Simple Bubble3D chart with axis titles``
                );
            ]
        ]
        
module Surface =
    [<Tests>]
    let ``Surface chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Surface" [
                 testCase "First surface data" ( fun () ->
                    // the data generated by this chart generates a
                    // line of code which is 200 Kb long, unreasonably
                    // huge for a test.
                    [
                        "var data = [{\"type\":\"surface\",\"z\":[[0.3929110807586562,0.39272903726671055,0.3923748718856843,0.3918384347714509,0.39110921172503726,0.39017633288191317,0.38902858492457726"
                        "-0.3755066766683234,-0.38085145315419006,-0.38575670319102695,-0.3902383753762268,-0.3943127362115111,-0.3979962450330162,-0.4013054412792835"
                        "-0.3901763328819132,-0.39110921172503726,-0.39183843477145097,-0.3923748718856844,-0.39272903726671055,-0.3929110807586562]]}];"
                    ]
                    |> chartGeneratedContainsList Surface.``Peak and sink surface plot``
                );
                testCase "First surface layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains Surface.``Peak and sink surface plot``
                );
                testCase "Second surface data" ( fun () ->
                    """var data = [{"type":"surface","opacity":0.5,"x":[0.0,2.5],"y":[0.0,2.5],"z":[[1.0,1.0],[1.0,2.0]],"contours":{"x":{"show":true},"y":{"show":true},"z":{"show":true}}}];"""
                    |> chartGeneratedContains Surface.``Surface plot with x/y indices mapping to z matrix with contours``
                );
                testCase "Second surface layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains Surface.``Surface plot with x/y indices mapping to z matrix with contours``
                );
            ]
        ]
        
module Mesh3D =
    [<Tests>]
    let ``Mesh3D chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Mesh3D" [
                testCase "Mesh data" ( fun () ->
                    """var data = [{"type":"mesh3d","x":[0.33836984091362443,0.2844184475412678,0.2629626417825756,0.6253758443637638,0.46346185284827923,0.9283738280312968,0.1463105539541275,0.9505998873853124,0.5961332552116985,0.11745994590104555,0.975558924477342,0.37088692624628866,0.0699143670824889,0.07078822472635109,0.48201058175508427,0.15297147219673332,0.9641655045394625,0.09534371648698287,0.8125330809562156,0.2506162050415837,0.48126059979259067,0.07473527084790882,0.8369272271343168,0.7793545950107996,0.18997055114711195,0.7421991949631829,0.2328434778530353,0.7856600809775572,0.9278804142623583,0.10790790343094053,0.03301328235911824,0.770361295794305,0.30779169793603556,0.11389689665003536,0.388590590743623,0.9796536713743832,0.17214082375734152,0.7884985966554371,0.1994013894346549,0.7964705586416976,0.3436089406458703,0.10509170037931376,0.9796912223006092,0.8392714871276503,0.5432778380547081,0.1979652751227679,0.038267011306372944,0.5355382620056803,0.6352935864754456,0.8821615948724382],"y":[0.9909701128448221,0.9722291035448336,0.2536179266188377,0.5066026125599642,0.19606175189654423,0.2636345700657156,0.447491220406951,0.48360804677177593,0.4354052932166519,0.7212626578850964,0.6955303501782615,0.3606504729765702,0.022719473122954123,0.48822535178075793,0.08444666354192731,0.20519762868303695,0.06309522831025312,0.9560174704324536,0.682197633982728,0.5023569103807011,0.9808306484393918,0.17566690788402545,0.8959423270523279,0.016062522314518,0.9070072643957134,0.37616889941327686,0.0950440485472996,0.9976557400066665,0.2360767569560915,0.9920052760243441,0.70393218365681,0.6973052158473549,0.15036649450211156,0.04571881938992013,0.11693779058611849,0.060784178814284585,0.5167433691754674,0.8011890853760714,0.9178351447534912,0.1249560206779074,0.5321624509674322,0.6885327769855656,0.35309330343878514,0.47813873154955855,0.10094020846343608,0.9829584676693001,0.08237222725635963,0.4914658705198513,0.754824823585723,0.33808020937167116],"z":[0.1348700468125148,0.0822495408739194,0.8533406280229523,0.13293667609474466,0.9013309464330463,0.8153032049607966,0.07628677649250569,0.2375554043043197,0.5995953481642508,0.8198928524832674,0.16859052151841603,0.44983548040028454,0.24753128981568445,0.44340001719230787,0.017330474228286406,0.9982251343309065,0.21028397847445868,0.977000653733034,0.37128756119463946,0.023662484727642725,0.6884542595075696,0.2619061429341818,0.03818232567896243,0.5572416133048207,0.9701944594132688,0.29229787145382624,0.8225736044452403,0.4178035955027694,0.9151223138510819,0.9240487967264135,0.29379667215691724,0.6035781780274483,0.24283091642094354,0.8979965475844204,0.8571352292118293,0.6216826427828905,0.8439645878244026,0.0174298184073669,0.1443878729568738,0.30163458562532186,0.9844974023217788,0.2791879648711476,0.20159373721182056,0.09794229227022375,0.9563654991594914,0.0823269705671477,0.44100148716988113,0.9096932862464773,0.4608082573212722,0.10271507413252959],"contour":{"show":true},"flatshading":true}];"""
                    |> chartGeneratedContains Mesh3D.``Mesh3D chart with random x/x/z data``
                );
                testCase "Mesh layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains Mesh3D.``Mesh3D chart with random x/x/z data``
                );
            ]
        ]
        
module Cone =
    [<Tests>]
    let ``Cone chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Cone" [
                testCase "Cone data" ( fun () ->
                    """var data = [{"type":"cone","x":[1,1,1],"y":[1,2,3],"z":[1,1,1],"u":[1,2,3],"v":[1,1,2],"w":[4,4,1],"colorscale":"Viridis"}];"""
                    |> chartGeneratedContains Cone.``Simple cone chart``
                );
                testCase "Cone layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains Cone.``Simple cone chart``
                );
            ]
        ]
        
module StreamTube =
    [<Tests>]
    let ``StreamTube chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "StreamTube" [
                testCase "StreamTube data" ( fun () ->
                    """var data = [{"type":"streamtube","x":[0,0,0],"y":[0,1,2],"z":[0,0,0],"u":[0,0,0],"v":[1,1,1],"w":[0,0,0],"colorscale":"Viridis"}];"""
                    |> chartGeneratedContains StreamTube.``Simple StreamTube chart ``
                );
                testCase "StreamTube layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains StreamTube.``Simple StreamTube chart ``
                );
            ]
        ]
        
module Volume =
    [<Tests>]
    let ``Volume chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "Volume" [
                testCase "Volume data" ( fun () ->
                    """var data = [{"type":"volume","x":[1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0],"y":[1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0],"z":[1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0],"value":[1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0],"colorscale":"Viridis"}];"""
                    |> chartGeneratedContains Volume.``Fancy mgrid based volume chart``
                );
                testCase "Volume layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains Volume.``Fancy mgrid based volume chart``
                );
            ]
        ]
        
module IsoSurface =
    [<Tests>]
    let ``IsoSurface chart HTML codegeneration tests`` =
        testList "HTMLCodegen.Chart3D" [
            testList "IsoSurface" [
                testCase "IsoSurface data" ( fun () ->
                    """var data = [{"type":"isosurface","x":[1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0,2.0],"y":[1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0,1.0,1.0,1.0,1.0,1.333,1.333,1.333,1.333,1.667,1.667,1.667,1.667,2.0,2.0,2.0,2.0],"z":[1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0],"value":[1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0,1.0,1.333,1.667,2.0],"colorscale":"Viridis"}];"""
                    |> chartGeneratedContains IsoSurface.``Fancy mgrid based isosurface chart``
                );
                testCase "IsoSurface layout" ( fun () ->
                    """var layout = {"scene":{"camera":{"projection":{"type":"perspective"}}}};"""
                    |> chartGeneratedContains IsoSurface.``Fancy mgrid based isosurface chart``
                );
            ]
        ]
