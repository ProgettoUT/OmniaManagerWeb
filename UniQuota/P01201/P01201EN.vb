Namespace P01201
    Public Enum TipoSezione
        Persona
        Famiglia
        Veicolo
        Malattia
        Assistenza
    End Enum
    Public Enum TipoPartita
        Persona
        Famiglia
        Veicolo
        Malattia
        Assistenza
    End Enum
    Public Enum TipoGaranzia
        PersonaBase
        PersonaMorte
        PersonaIP
        PersonaIT
        PersonaRicovero
        PersonaImmobilizzazione
        PersonaSpeseMediche
        PersonaRenditaVitalizia
        PersonaFranchigiaRelativa
        PersonaFranchigia5
        PersonaFranchigia3
        PersonaFranchigiaDifferenziata
        PersonaIndennizzoVariabile
        PersonaSpecifica
        PersonaMaggiorazione
        PersonaTabellaINAIL
        PersonaTabellaUGFPLUS
        PersonaRischiDomestivi
        PersonaSportsAltoRischioMorte
        PersonaSportsAltoRischioIP
        PersonaSportsAltoRischioRicovero
        PersonaSportsAltoRischioSpeseMediche
        PersonaSportsMotoristiciMorte
        PersonaSportsMotoristiciIP
        PersonaSportsAereiMorte
        PersonaSportsAereiIP
        PersonaEsclusioneGuidaMotoveicoli
        PersonaEsclusioneSports
        FamigliaBase
        FamigliaMorte
        FamigliaIP
        FamigliaRicoveroConvalescenza
        FamigliaImmobilizzazione
        FamigliaSpeseMediche
        FamigliaTabellaINAIL
        FamigliaFranchigiaDifferenziata
        FamigliaRischiDomestivi
        VeicoloBase
        VeicoloMorte
        VeicoloIP
        VeicoloRicoveroConvalescenza
        VeicoloImmobilizzazione
        VeicoloSpeseMediche
        VeicoloTabellaINAIL
        VeicoloFranchigiaDifferenziata
        VeicoloFranchigia5
        VeicoloFranchigiaAssoluta
        MalattiaBase
        MalattiaInvaliditaPermanente
        MalattiaInabilitaTemporanea
        MalattiaRicovero
        MalattiaImmobilizzazione
        AssistenzaBase
    End Enum

    Public Enum RischioProfessionaleEnum
        ClasseA = 1
        ClasseB = 2
        ClasseC = 3
        ClasseD = 4
        ClasseRD = 5
    End Enum

    Public Enum AttivitaProfessionaleEnum
        Dipendente = 1
        LiberoProfessionista = 2
        NoAttivitaProfessionale = 3
    End Enum

    Public Enum PersonaSceltaFormaEnum
        TempoLiberoLavoroAll = 1
        TempoLiberoLavoroPrf = 2
        TempoLiberoLavoroExt = 3
        TempoLiberoLavoroTop = 4
        FullTime = 5
        FullTimeTop = 6
        FullTimeFormulaFacile01 = 11
        FullTimeFormulaFacile02 = 12
        FullTimeFormulaFacile03 = 13
        FullTimeFormulaFacile04 = 14
        FullTimeFormulaFacile05 = 15
        FullTimeFormulaFacile06 = 16
        FullTimeFormulaFacile07 = 17
        FullTimeFormulaFacile08 = 18
        FullTimeFormulaFacile09 = 19
        FullTimeFormulaFacile10 = 20
        FullTimeFormulaFacile11 = 21
        FullTimeFormulaFacile12 = 22
        Circolazione01 = 31
        Circolazione02 = 32
        Circolazione03 = 33
        Circolazione04 = 34
        Circolazione05 = 35
        Circolazione06 = 36
        Circolazione07 = 37
        Circolazione08 = 38
        Circolazione09 = 39
        Circolazione10 = 40
        Circolazione11 = 41
        Circolazione12 = 42
    End Enum

    Public Enum PersonaITFormaEnum
        PersonaITParziale = 0
        PersonaITIntegrale = 1
        PersonaITRicovero = 2
    End Enum

    Public Enum PersonaRicoveroFormaEnum
        PersonaRicoveroSoloRicovero = 0
        PersonaRicoveroConvalescenza = 1
        PersonaRicoveroConvalescenzaProlungata = 2
    End Enum

    Public Enum PersonaImmobilizzazioneFormaEnum
        PersonaImmobilizzazioneNormale = 0
        PersonaImmobilizzazioneProlungata = 1
    End Enum

    Public Enum FamigliaSceltaFormaEnum
        FullTimeFormulaFacile11 = 11
        FullTimeFormulaFacile12 = 12
        FullTimeFormulaFacile13 = 13
        FullTimeFormulaFacile14 = 14
        FullTimeFormulaFacile15 = 15
        FullTimeFormulaFacile16 = 16
        FullTimeFormulaFacile17 = 17
        FullTimeFormulaFacile18 = 18
        FullTimeFormulaFacile19 = 19
        FullTimeFormulaFacile20 = 20
        FullTimeFormulaFacile21 = 21
        FullTimeFormulaFacile22 = 22
        Circolazione01 = 31
        Circolazione02 = 32
        Circolazione03 = 33
        Circolazione04 = 34
        Circolazione05 = 35
        Circolazione06 = 36
        Circolazione07 = 37
        Circolazione08 = 38
        Circolazione09 = 39
        Circolazione10 = 40
        Circolazione11 = 41
        Circolazione12 = 42
    End Enum

    Public Enum VeicoloSceltaFormaEnum
        CapitaliLiberi = 1
        Circolazione01 = 31
        Circolazione02 = 32
        Circolazione03 = 33
        Circolazione04 = 34
        Circolazione05 = 35
        Circolazione06 = 36
        Circolazione07 = 37
        Circolazione08 = 38
        Circolazione09 = 39
        Circolazione10 = 40
        Circolazione11 = 41
        Circolazione12 = 42
    End Enum

    Public Enum TipologiaVeicoloEnum
        Autovetture = 5
        AutoMotocarri = 6
        Motocicli = 7
        Ciclomotori = 8
    End Enum

    Public Enum VeicoloRicoveroFormaEnum
        VeicoloRicoveroSoloRicovero = 0
        VeicoloRicoveroConvalescenza = 1
    End Enum


    Public Enum MalattiaITSceltaFormaEnum
        RicoveroConvalescenza = 1
        Integrale = 2
    End Enum

    Public Enum MalattiaRicoveroSceltaFormaEnum
        SoloRicovero = 1
        RicoveroConvalescenza = 2
    End Enum

    Public Enum AssistenzaPacchettoEnum
        PacchettoCompleto = 1
        PacchettoTop = 2
        PacchettoComfort = 3
        PacchettoClassico = 4
    End Enum

    Public Enum TipoAttivitaEnum
        Attivita0 = 0
        Attivita1 = 1
        Attivita2 = 2
        Attivita3 = 3
        Attivita4 = 4
        Attivita5 = 5
        Attivita6 = 6
        Attivita7 = 7
        Attivita8 = 8
        Attivita9 = 9
        Attivita10 = 10
        Attivita11 = 11
        Attivita12 = 12
        Attivita13 = 13
        Attivita14 = 14
        Attivita15 = 15
        Attivita16 = 16
        Attivita17 = 17
        Attivita18 = 18
        Attivita19 = 19
        Attivita20 = 20
        Attivita21 = 21
        Attivita22 = 22
        Attivita23 = 23
        Attivita24 = 24
        Attivita25 = 25
        Attivita26 = 26
        Attivita27 = 27
        Attivita28 = 28
        Attivita29 = 29
        Attivita30 = 30
        Attivita31 = 31
        Attivita32 = 32
        Attivita33 = 33
        Attivita34 = 34
        Attivita35 = 35
        Attivita36 = 36
        Attivita37 = 37
        Attivita38 = 38
        Attivita39 = 39
        Attivita40 = 40
        Attivita41 = 41
        Attivita42 = 42
        Attivita43 = 43
        Attivita44 = 44
        Attivita45 = 45
        Attivita46 = 46
        Attivita47 = 47
        Attivita48 = 48
        Attivita49 = 49
        Attivita50 = 50
        Attivita51 = 51
        Attivita52 = 52
        Attivita53 = 53
        Attivita54 = 54
        Attivita55 = 55
        Attivita56 = 56
        Attivita57 = 57
        Attivita58 = 58
        Attivita59 = 59
        Attivita60 = 60
        Attivita61 = 61
        Attivita62 = 62
        Attivita63 = 63
        Attivita64 = 64
        Attivita65 = 65
        Attivita66 = 66
        Attivita67 = 67
        Attivita68 = 68
        Attivita69 = 69
        Attivita70 = 70
        Attivita71 = 71
        Attivita72 = 72
        Attivita73 = 73
        Attivita74 = 74
        Attivita75 = 75
        Attivita76 = 76
        Attivita77 = 77
        Attivita78 = 78
        Attivita79 = 79
        Attivita80 = 80
        Attivita81 = 81
        Attivita82 = 82
        Attivita83 = 83
        Attivita84 = 84
        Attivita85 = 85
        Attivita86 = 86
        Attivita87 = 87
        Attivita88 = 88
        Attivita89 = 89
        Attivita90 = 90
        Attivita91 = 91
        Attivita92 = 92
        Attivita93 = 93
        Attivita94 = 94
        Attivita95 = 95
        Attivita96 = 96
        Attivita97 = 97
        Attivita98 = 98
        Attivita99 = 99
        Attivita100 = 100
        Attivita101 = 101
        Attivita102 = 102
        Attivita103 = 103
        Attivita104 = 104
        Attivita105 = 105
        Attivita106 = 106
        Attivita107 = 107
        Attivita108 = 108
        Attivita109 = 109
        Attivita110 = 110
        Attivita111 = 111
        Attivita112 = 112
        Attivita113 = 113
        Attivita114 = 114
        Attivita115 = 115
        Attivita116 = 116
        Attivita117 = 117
        Attivita118 = 118
        Attivita119 = 119
        Attivita120 = 120
        Attivita121 = 121
        Attivita122 = 122
        Attivita123 = 123
        Attivita124 = 124
        Attivita125 = 125
        Attivita126 = 126
        Attivita127 = 127
        Attivita128 = 128
        Attivita129 = 129
        Attivita130 = 130
        Attivita131 = 131
        Attivita132 = 132
        Attivita133 = 133
        Attivita134 = 134
        Attivita135 = 135
        Attivita136 = 136
        Attivita137 = 137
        Attivita138 = 138
        Attivita139 = 139
        Attivita140 = 140
        Attivita141 = 141
        Attivita142 = 142
        Attivita143 = 143
        Attivita144 = 144
        Attivita145 = 145
        Attivita146 = 146
        Attivita147 = 147
        Attivita148 = 148
        Attivita149 = 149
        Attivita150 = 150
        Attivita151 = 151
        Attivita152 = 152
        Attivita153 = 153
        Attivita154 = 154
        Attivita155 = 155
        Attivita156 = 156
        Attivita157 = 157
        Attivita158 = 158
        Attivita159 = 159
        Attivita160 = 160
        Attivita161 = 161
        Attivita162 = 162
        Attivita163 = 163
        Attivita164 = 164
        Attivita165 = 165
        Attivita166 = 166
        Attivita167 = 167
        Attivita168 = 168
        Attivita169 = 169
        Attivita170 = 170
        Attivita171 = 171
        Attivita172 = 172
        Attivita173 = 173
        Attivita174 = 174
        Attivita175 = 175
        Attivita176 = 176
        Attivita177 = 177
        Attivita178 = 178
        Attivita179 = 179
        Attivita180 = 180
        Attivita181 = 181
        Attivita182 = 182
        Attivita183 = 183
        Attivita184 = 184
        Attivita185 = 185
        Attivita186 = 186
        Attivita187 = 187
        Attivita188 = 188
        Attivita189 = 189
        Attivita190 = 190
        Attivita191 = 191
        Attivita192 = 192
        Attivita193 = 193
        Attivita194 = 194
        Attivita195 = 195
        Attivita196 = 196
        Attivita197 = 197
        Attivita198 = 198
        Attivita199 = 199
        Attivita200 = 200
        Attivita201 = 201
        Attivita202 = 202
        Attivita203 = 203
        Attivita204 = 204
        Attivita205 = 205
        Attivita206 = 206
        Attivita207 = 207
        Attivita208 = 208
        Attivita209 = 209
        Attivita210 = 210
        Attivita211 = 211
        Attivita212 = 212
        Attivita213 = 213
        Attivita214 = 214
        Attivita215 = 215
        Attivita216 = 216
        Attivita217 = 217
        Attivita218 = 218
        Attivita219 = 219
        Attivita220 = 220
        Attivita221 = 221
        Attivita222 = 222
        Attivita223 = 223
        Attivita224 = 224
        Attivita225 = 225
        Attivita226 = 226
        Attivita227 = 227
        Attivita228 = 228
        Attivita229 = 229
        Attivita230 = 230
        Attivita231 = 231
        Attivita232 = 232
        Attivita233 = 233
        Attivita234 = 234
        Attivita235 = 235
        Attivita236 = 236
        Attivita237 = 237
        Attivita238 = 238
        Attivita239 = 239
        Attivita240 = 240
        Attivita241 = 241
        Attivita242 = 242
        Attivita243 = 243
        Attivita244 = 244
        Attivita245 = 245
        Attivita246 = 246
        Attivita247 = 247
        Attivita248 = 248
        Attivita249 = 249
        Attivita250 = 250
        Attivita251 = 251
        Attivita252 = 252
        Attivita253 = 253
        Attivita254 = 254
        Attivita255 = 255
        Attivita256 = 256
        Attivita257 = 257
        Attivita258 = 258
        Attivita259 = 259
        Attivita260 = 260
        Attivita261 = 261
        Attivita262 = 262
        Attivita263 = 263
        Attivita264 = 264
        Attivita265 = 265
        Attivita266 = 266
        Attivita267 = 267
        Attivita268 = 268
        Attivita269 = 269
        Attivita270 = 270
        Attivita271 = 271
        Attivita272 = 272
        Attivita273 = 273
        Attivita274 = 274
        Attivita275 = 275
        Attivita276 = 276
        Attivita277 = 277
        Attivita278 = 278
        Attivita279 = 279
        Attivita280 = 280
        Attivita281 = 281
        Attivita282 = 282
        Attivita283 = 283
        Attivita284 = 284
        Attivita285 = 285
        Attivita286 = 286
        Attivita287 = 287
        Attivita288 = 288
        Attivita289 = 289
        Attivita290 = 290
        Attivita291 = 291
        Attivita292 = 292
        Attivita293 = 293
        Attivita294 = 294
        Attivita295 = 295
        Attivita296 = 296
        Attivita297 = 297
        Attivita298 = 298
        Attivita299 = 299
        Attivita300 = 300
        Attivita301 = 301
        Attivita302 = 302
        Attivita303 = 303
        Attivita304 = 304
        Attivita305 = 305
        Attivita306 = 306
        Attivita307 = 307
        Attivita308 = 308
        Attivita309 = 309
        Attivita310 = 310
        Attivita311 = 311
        Attivita312 = 312
        Attivita313 = 313
        Attivita314 = 314
        Attivita315 = 315
        Attivita316 = 316
        Attivita317 = 317
        Attivita318 = 318
        Attivita319 = 319
        Attivita320 = 320
        Attivita321 = 321
        Attivita322 = 322
        Attivita323 = 323
        Attivita324 = 324
        Attivita325 = 325
        Attivita326 = 326
        Attivita327 = 327
        Attivita328 = 328
        Attivita329 = 329
        Attivita330 = 330
        Attivita331 = 331
        Attivita332 = 332
        Attivita333 = 333
        Attivita334 = 334
        Attivita335 = 335
        Attivita336 = 336
        Attivita337 = 337
        Attivita338 = 338
        Attivita339 = 339
        Attivita340 = 340
        Attivita341 = 341
        Attivita342 = 342
        Attivita343 = 343
        Attivita344 = 344
        Attivita345 = 345
        Attivita346 = 346
        Attivita347 = 347
        Attivita348 = 348
        Attivita349 = 349
        Attivita350 = 350
        Attivita351 = 351
        Attivita352 = 352
        Attivita353 = 353
        Attivita354 = 354
        Attivita355 = 355
        Attivita356 = 356
        Attivita357 = 357
        Attivita358 = 358
        Attivita359 = 359
        Attivita360 = 360
        Attivita361 = 361
        Attivita362 = 362
        Attivita363 = 363
        Attivita364 = 364
        Attivita365 = 365
        Attivita366 = 366
        Attivita367 = 367
        Attivita368 = 368
        Attivita369 = 369
        Attivita370 = 370
        Attivita371 = 371
        Attivita372 = 372
        Attivita373 = 373
        Attivita374 = 374
        Attivita375 = 375
        Attivita376 = 376
        Attivita377 = 377
        Attivita378 = 378
        Attivita379 = 379
        Attivita380 = 380
        Attivita381 = 381
        Attivita382 = 382
        Attivita383 = 383
        Attivita384 = 384
        Attivita385 = 385
        Attivita386 = 386
        Attivita387 = 387
        Attivita388 = 388
        Attivita389 = 389
        Attivita390 = 390
        Attivita391 = 391
        Attivita392 = 392
        Attivita393 = 393
        Attivita394 = 394
        Attivita395 = 395
        Attivita396 = 396
        Attivita397 = 397
        Attivita398 = 398
        Attivita399 = 399
        Attivita400 = 400
        Attivita401 = 401
        Attivita402 = 402
        Attivita403 = 403
        Attivita404 = 404
        Attivita405 = 405
        Attivita406 = 406
        Attivita407 = 407
        Attivita408 = 408
        Attivita409 = 409
        Attivita410 = 410
        Attivita411 = 411
        Attivita412 = 412
        Attivita413 = 413
        Attivita414 = 414
        Attivita415 = 415
        Attivita416 = 416
        Attivita417 = 417
        Attivita418 = 418
        Attivita419 = 419
        Attivita420 = 420
        Attivita421 = 421
        Attivita422 = 422
        Attivita423 = 423
        Attivita424 = 424
        Attivita425 = 425
        Attivita426 = 426
        Attivita427 = 427
        Attivita428 = 428
        Attivita429 = 429
        Attivita430 = 430
        Attivita431 = 431
        Attivita432 = 432
        Attivita433 = 433
        Attivita434 = 434
        Attivita435 = 435
        Attivita436 = 436
        Attivita437 = 437
        Attivita438 = 438
        Attivita439 = 439
        Attivita440 = 440
        Attivita441 = 441
        Attivita442 = 442
        Attivita443 = 443
        Attivita444 = 444
        Attivita445 = 445
        Attivita446 = 446
        Attivita447 = 447
        Attivita448 = 448
        Attivita449 = 449
        Attivita450 = 450
        Attivita451 = 451
        Attivita452 = 452
        Attivita453 = 453
        Attivita454 = 454
        Attivita455 = 455
        Attivita456 = 456
        Attivita457 = 457
        Attivita458 = 458
        Attivita459 = 459
        Attivita460 = 460
        Attivita461 = 461
        Attivita462 = 462
        Attivita463 = 463
        Attivita464 = 464
        Attivita465 = 465
        Attivita466 = 466
        Attivita467 = 467
        Attivita468 = 468
        Attivita469 = 469
        Attivita470 = 470
        Attivita471 = 471
        Attivita472 = 472
        Attivita473 = 473
        Attivita474 = 474
        Attivita475 = 475
        Attivita476 = 476
        Attivita477 = 477
        Attivita478 = 478
        Attivita999 = 999
    End Enum
End Namespace
