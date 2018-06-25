using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistaDM.Web.Models
{
    public class AssesmentScreen5_Model
    {

        public bool ReadOnly { get; set; }
        
        public QuestionModel q1 { get; set; }
        public QuestionModel q2 { get; set; }
        public QuestionModel q3 { get; set; }
        public QuestionModel q4 { get; set; }
        public QuestionModel q5 { get; set; }
        public QuestionModel q6 { get; set; }
        public QuestionModel q7 { get; set; }
        public QuestionModel q8 { get; set; }
        public QuestionModel q9 { get; set; }
        public QuestionModel q10 { get; set; }
        public QuestionModel q11 { get; set; }
        public QuestionModel q12 { get; set; }
        public QuestionModel q13 { get; set; }
        public QuestionModel q14 { get; set; }
        public QuestionModel q15 { get; set; }
        public QuestionModel q16 { get; set; }
        public QuestionModel q17 { get; set; }
        public QuestionModel q18 { get; set; }
        public QuestionModel q19 { get; set; }
        public QuestionModel q20 { get; set; }
        public QuestionModel q21 { get; set; }
        public QuestionModel q22 { get; set; }
        public QuestionModel q23 { get; set; }
        public QuestionModel q24 { get; set; }
        public QuestionModel q25 { get; set; }
        public QuestionModel q26 { get; set; }

        public bool Completed { get; set; }

        public AssesmentScreen5_Model()
        {
            q1 = new QuestionModel();
            q1.QID = 52;
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 246 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 247 });
            q1.Answer.Add(new AnswerModel() { QID = q1.QID, AID = 248 });

            q2 = new QuestionModel();
            q2.QID = 53;
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 249 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 250 });
            q2.Answer.Add(new AnswerModel() { QID = q2.QID, AID = 251 });

            q3 = new QuestionModel();
            q3.QID = 54;
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 252 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 253 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 254 });
            q3.Answer.Add(new AnswerModel() { QID = q3.QID, AID = 255 });

            q4 = new QuestionModel();
            q4.QID = 55;
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 256 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 257 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 258 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 259 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 260 });
            q4.Answer.Add(new AnswerModel() { QID = q4.QID, AID = 261 });

            q5 = new QuestionModel();
            q5.QID = 56;
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 262 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 263 });
            q5.Answer.Add(new AnswerModel() { QID = q5.QID, AID = 264 });

            q6 = new QuestionModel();
            q6.QID = 57;
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 265 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 266 });
            q6.Answer.Add(new AnswerModel() { QID = q6.QID, AID = 267 });

            q7 = new QuestionModel();
            q7.QID = 58;
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 268 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 269 });
            q7.Answer.Add(new AnswerModel() { QID = q7.QID, AID = 270 });

            q8 = new QuestionModel();
            q8.QID = 77;
            q8.Answer.Add(new AnswerModel() { QID = q8.QID, AID = 271 });

            q9 = new QuestionModel();
            q9.QID = 59;
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 272 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 273 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 274 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 275 });
            q9.Answer.Add(new AnswerModel() { QID = q9.QID, AID = 276 });

            q10 = new QuestionModel();
            q10.QID = 60;
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 277 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 278 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 279 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 280 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 281 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 282 });
            q10.Answer.Add(new AnswerModel() { QID = q10.QID, AID = 283 });

            q10.SelectedAnswers.Add(new AnswerModel() { AID = 277 });
            q10.SelectedAnswers.Add(new AnswerModel() { AID = 278 });
            q10.SelectedAnswers.Add(new AnswerModel() { AID = 279 });
            q10.SelectedAnswers.Add(new AnswerModel() { AID = 280 });
            q10.SelectedAnswers.Add(new AnswerModel() { AID = 281 });
            q10.SelectedAnswers.Add(new AnswerModel() { AID = 282 });
            q10.SelectedAnswers.Add(new AnswerModel() { AID = 283 });


            q11 = new QuestionModel();
            q11.QID = 61;
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 284 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 285 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 286 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 287 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 288 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 289 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 290 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 291 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 292 });
            q11.Answer.Add(new AnswerModel() { QID = q11.QID, AID = 293 });

            q11.SelectedAnswers.Add(new AnswerModel() { AID = 284 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 285 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 286 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 287 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 288 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 289 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 290 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 291 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 292 });
            q11.SelectedAnswers.Add(new AnswerModel() { AID = 293 });

            q12 = new QuestionModel();
            q12.QID = 62;
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 294 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 295 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 296 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 297 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 298 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 299 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 300 });
            q12.Answer.Add(new AnswerModel() { QID = q12.QID, AID = 301 });


            q12.SelectedAnswers.Add(new AnswerModel() { AID = 294 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 295 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 296 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 297 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 298 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 299 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 300 });
            q12.SelectedAnswers.Add(new AnswerModel() { AID = 301 });


            q13 = new QuestionModel();
            q13.QID = 63;
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 302 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 303 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 304 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 305 });
            q13.Answer.Add(new AnswerModel() { QID = q13.QID, AID = 306 });

            q14 = new QuestionModel();
            q14.QID = 64;
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 307 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 308 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 309 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 310 });
            q14.Answer.Add(new AnswerModel() { QID = q14.QID, AID = 311 });

            q15 = new QuestionModel();
            q15.QID = 65;
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 312 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 313 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 314 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 315 });
            q15.Answer.Add(new AnswerModel() { QID = q15.QID, AID = 316 });

            q16 = new QuestionModel();
            q16.QID = 66;
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 317 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 318 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 319 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 320 });
            q16.Answer.Add(new AnswerModel() { QID = q16.QID, AID = 321 });

            q17 = new QuestionModel();
            q17.QID = 67;
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 322 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 323 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 324 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 325 });
            q17.Answer.Add(new AnswerModel() { QID = q17.QID, AID = 326 });


            q18 = new QuestionModel();
            q18.QID = 68;
            q18.Answer.Add(new AnswerModel() { QID = q18.QID, AID = 327 });
            q18.Answer.Add(new AnswerModel() { QID = q18.QID, AID = 328 });
            q18.Answer.Add(new AnswerModel() { QID = q18.QID, AID = 329 });
            q18.Answer.Add(new AnswerModel() { QID = q18.QID, AID = 330 });
            q18.Answer.Add(new AnswerModel() { QID = q18.QID, AID = 331 });

            q19 = new QuestionModel();
            q19.QID = 69;
            q19.Answer.Add(new AnswerModel() { QID = q19.QID, AID = 332 });
            q19.Answer.Add(new AnswerModel() { QID = q19.QID, AID = 333 });
            q19.Answer.Add(new AnswerModel() { QID = q19.QID, AID = 334 });
            q19.Answer.Add(new AnswerModel() { QID = q19.QID, AID = 335 });
            q19.Answer.Add(new AnswerModel() { QID = q19.QID, AID = 336 });

            q20 = new QuestionModel();
            q20.QID = 70;
            q20.Answer.Add(new AnswerModel() { QID = q20.QID, AID = 337 });
            q20.Answer.Add(new AnswerModel() { QID = q20.QID, AID = 338 });
            q20.Answer.Add(new AnswerModel() { QID = q20.QID, AID = 339 });
            q20.Answer.Add(new AnswerModel() { QID = q20.QID, AID = 340 });
            q20.Answer.Add(new AnswerModel() { QID = q20.QID, AID = 341 });

            q21 = new QuestionModel();
            q21.QID = 71;
            q21.Answer.Add(new AnswerModel() { QID = q21.QID, AID = 342 });
            q21.Answer.Add(new AnswerModel() { QID = q21.QID, AID = 343 });
            q21.Answer.Add(new AnswerModel() { QID = q21.QID, AID = 344 });
            q21.Answer.Add(new AnswerModel() { QID = q21.QID, AID = 345 });
            q21.Answer.Add(new AnswerModel() { QID = q21.QID, AID = 346 });

            q22 = new QuestionModel();
            q22.QID = 72;
            q22.Answer.Add(new AnswerModel() { QID = q22.QID, AID = 347 });
            q22.Answer.Add(new AnswerModel() { QID = q22.QID, AID = 348 });
            q22.Answer.Add(new AnswerModel() { QID = q22.QID, AID = 349 });
            q22.Answer.Add(new AnswerModel() { QID = q22.QID, AID = 350 });
            q22.Answer.Add(new AnswerModel() { QID = q22.QID, AID = 351 });

            q23 = new QuestionModel();
            q23.QID = 73;
            q23.Answer.Add(new AnswerModel() { QID = q23.QID, AID = 352 });
            q23.Answer.Add(new AnswerModel() { QID = q23.QID, AID = 353 });
            q23.Answer.Add(new AnswerModel() { QID = q23.QID, AID = 354 });
            q23.Answer.Add(new AnswerModel() { QID = q23.QID, AID = 355 });
            q23.Answer.Add(new AnswerModel() { QID = q23.QID, AID = 356 });

            q24 = new QuestionModel();
            q24.QID = 74;
            q24.Answer.Add(new AnswerModel() { QID = q24.QID, AID = 357 });
            q24.Answer.Add(new AnswerModel() { QID = q24.QID, AID = 358 });
            q24.Answer.Add(new AnswerModel() { QID = q24.QID, AID = 359 });
            q24.Answer.Add(new AnswerModel() { QID = q24.QID, AID = 360 });
            q24.Answer.Add(new AnswerModel() { QID = q24.QID, AID = 361 });
            q24.Answer.Add(new AnswerModel() { QID = q24.QID, AID = 362 });


            q24.SelectedAnswers.Add(new AnswerModel() { AID = 357 });
            q24.SelectedAnswers.Add(new AnswerModel() { AID = 358 });
            q24.SelectedAnswers.Add(new AnswerModel() { AID = 359 });
            q24.SelectedAnswers.Add(new AnswerModel() { AID = 360 });
            q24.SelectedAnswers.Add(new AnswerModel() { AID = 361 });
            q24.SelectedAnswers.Add(new AnswerModel() { AID = 362 });

            q25 = new QuestionModel();
            q25.QID = 75;
            q25.Answer.Add(new AnswerModel() { QID = q25.QID, AID = 363 });
            q25.Answer.Add(new AnswerModel() { QID = q25.QID, AID = 364 });
            q25.Answer.Add(new AnswerModel() { QID = q25.QID, AID = 365 });
            q25.Answer.Add(new AnswerModel() { QID = q25.QID, AID = 366 });
            q25.Answer.Add(new AnswerModel() { QID = q25.QID, AID = 367 });
            q25.Answer.Add(new AnswerModel() { QID = q25.QID, AID = 368 });

            q26 = new QuestionModel();
            q26.QID = 76;
            q26.Answer.Add(new AnswerModel() { QID = q26.QID, AID = 369 });
            q26.Answer.Add(new AnswerModel() { QID = q26.QID, AID = 370 });
            q26.Answer.Add(new AnswerModel() { QID = q26.QID, AID = 371 });
            q26.Answer.Add(new AnswerModel() { QID = q26.QID, AID = 372 });
            q26.Answer.Add(new AnswerModel() { QID = q26.QID, AID = 373 });

        }
    }
}